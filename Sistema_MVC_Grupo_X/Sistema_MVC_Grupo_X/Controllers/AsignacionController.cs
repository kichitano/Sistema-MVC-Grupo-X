﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Grupo_X.Models;
using InteropExcel = Microsoft.Office.Interop.Excel;
using Spire.Xls;

namespace Sistema_MVC_Grupo_X.Controllers
{
    public class AsignacionController : Controller
    {
        private Asignacion objAsignacion = new Asignacion();
        private Semestre objSemestre = new Semestre();
        private Docente objDocente = new Docente();
        private Criterio objCriterio = new Criterio();
        private DetalleAsignacion objDetalleAsignacion = new DetalleAsignacion();

        //GET
        public ActionResult Index()
        {
            return View(objAsignacion.Listar());
        }
        public ActionResult Reporte()
        {
            return View(objAsignacion.Listar());
        }
        public ActionResult ExportarPDF()
        {
            List<Asignacion> listaAsignacion = objAsignacion.Listar();
            var destino = Server.MapPath(@"~/Assets/report/Asignacion.pdf");
            var filename = Server.MapPath(@"~/Assets/report/AsignacionChart.xlsx");
            int numeroFila = 3;
            //Crear una variable faltante para el valor perdido  
            object missing = System.Reflection.Missing.Value;
            var modelos = from grupo in listaAsignacion group grupo by grupo.semestre_id into grp select new { key = grp.Key, cnt = grp.Count() };
            string modelo = "";
            if (!System.IO.File.Exists(filename))
            {
                // Creamos un objeto Excel.
                InteropExcel.Application Mi_Excel = default(InteropExcel.Application);

                // Creamos un objeto WorkBook. Para crear el documento Excel.           
                InteropExcel.Workbook LibroExcel = default(InteropExcel.Workbook);
                // Creamos un objeto WorkSheet. Para crear la hoja del documento.
                InteropExcel.Worksheet HojaExcel = default(InteropExcel.Worksheet);

                // First column (1, in this case) will be the label
                Mi_Excel = new InteropExcel.Application();
                //Mi_Excel.Visible = true;


                /* Ahora creamos un nuevo documento y seleccionamos la primera hoja del 
                 * documento en la cual crearemos nuestro informe. 
                 */
                // Creamos una instancia del Workbooks de excel.            
                LibroExcel = Mi_Excel.Workbooks.Add();
                // Creamos una instancia de la primera hoja de trabajo de excel            
                HojaExcel = LibroExcel.Worksheets[1];

                HojaExcel.Visible = InteropExcel.XlSheetVisibility.xlSheetVisible;

                HojaExcel.Range["D1:G1"].Merge();
                HojaExcel.Range["D1:G1"].Value = "Reporte de Asignación";
                HojaExcel.Range["D1:G1"].Font.Italic = true;
                HojaExcel.Range["D1:G1"].Font.Size = 17;

                InteropExcel.Range currentRange = (InteropExcel.Range)HojaExcel.get_Range("C1", "G1");
                currentRange.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                HojaExcel.Cells[2, 4] = "Semestre";
                HojaExcel.Cells[2, 5] = "Asignación";



                
                foreach (var item in modelos)
                {
                    modelo = objSemestre.Obtener(item.key).nombre;
                    HojaExcel.Cells[numeroFila, 4] = modelo;
                    HojaExcel.Cells[numeroFila, 5] = item.cnt;
                    numeroFila++;
                }
                HojaExcel.Columns.AutoFit();
                InteropExcel.Range rangoBorde = (InteropExcel.Range)HojaExcel.get_Range("D2", "E" + (3 + modelos.Count()));
                InteropExcel.Borders borders = rangoBorde.Borders;
                //Set the hair lines style.
                borders.LineStyle = InteropExcel.XlLineStyle.xlDash;
                borders.Weight = 2d;

                InteropExcel.Range chartRange;

                InteropExcel.ChartObjects xlCharts = (InteropExcel.ChartObjects)HojaExcel.ChartObjects(Type.Missing);
                InteropExcel.ChartObject chartObj = (InteropExcel.ChartObject)xlCharts.Add(30, 100, 348, 268);
                InteropExcel.Chart chart = chartObj.Chart;

                // Define a range that encompasses the data above (including the label "cells")
                chartRange = HojaExcel.Range[HojaExcel.Cells[2, 4], HojaExcel.Cells[2 + modelos.Count(), 5]];
                chart.SetSourceData(chartRange, missing);
                chart.ChartType = InteropExcel.XlChartType.xlPieExploded;

                //InteropExcel.ChartObjects xlCharts2 = (InteropExcel.ChartObjects)HojaExcel.ChartObjects(Type.Missing);
                InteropExcel.ChartObject chartObj2 = (InteropExcel.ChartObject)xlCharts.Add(30, 400, 348, 268);
                InteropExcel.Chart chart2 = chartObj2.Chart;

                chartRange = HojaExcel.Range[HojaExcel.Cells[2, 4], HojaExcel.Cells[2 + modelos.Count(), 5]];
                chart2.SetSourceData(chartRange, missing);
                chart2.ChartType = InteropExcel.XlChartType.xlColumnClustered;
                // It is not enough to set the title; you also have to tell it that it has a title first
                chart.HasTitle = true;
                chart.ChartTitle.Text = "Cantidad de Asignaciones por Semestre";
                chart.ApplyDataLabels(InteropExcel.XlDataLabelsType.xlDataLabelsShowPercent, InteropExcel.XlDataLabelsType.xlDataLabelsShowLabel, true, false, false, true, false, true);

                LibroExcel.SaveAs(filename);

                ///Cerrar libro
                LibroExcel.Close(true, missing, missing);
                ///cerrar aplicación
                Mi_Excel.Quit();

            }
            else
            {
                //Iniciar aplicación
                InteropExcel.Application application = new InteropExcel.Application();
                //Iniciar archivo
                InteropExcel.Workbook workbook = application.Workbooks.Open(filename);
                InteropExcel.Worksheet HojaExcel = workbook.Worksheets[1];
                foreach (var item in modelos)
                {
                    modelo = objSemestre.Obtener(item.key).nombre;
                    HojaExcel.Cells[numeroFila, 4] = modelo;
                    HojaExcel.Cells[numeroFila, 5] = item.cnt;
                    numeroFila++;
                }
                workbook.Save();
                ///Cerrar libro
                workbook.Close(true, missing, missing);
                ///cerrar aplicación
                application.Quit();
            }

            convertToPDF(destino);


            return File(destino, "application/pdf", "Asignación.pdf");
        }
        public void convertToPDF(string destino)
        {

            var filename = Server.MapPath(@"~/Assets/report/AsignacionChart.xlsx");
            var _destino = destino;
            Workbook book = new Workbook();
            book.LoadFromFile(filename);
            book.SaveToFile(_destino, FileFormat.PDF);
        }

        //Action Visualizar
        public ActionResult Visualizar(int id)
        {
            return View(objAsignacion.Obtener(id));
        }

        //Accion agregarEditar
        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Semestre = objSemestre.Listar();
            ViewBag.Docente = objDocente.Listar();
            ViewBag.Criterio = objCriterio.Listar();
            ViewBag.DetalleAsignacion = objDetalleAsignacion.Listar();
            return View(
                id == 0 ? new Asignacion() //Agrega un nuevo objeto
                : objAsignacion.Obtener(id) //Devuelva un objeto
                );
        }

        //Accion guardar
        public ActionResult Guardar(Asignacion objAsignacion)
        {
            if (ModelState.IsValid)
            {
                objAsignacion.Guardar();
                return Redirect("~/Asignacion/AgregarEditar/" + objAsignacion.asignacion_id);
            }
            else
            {
                return View("~/Views/Asignacion/AgregarEditar.cshtml");
            }
        }

        //Accion eliminar
        public ActionResult Eliminar(int id)
        {
            objAsignacion.asignacion_id = id;
            objAsignacion.Eliminar();
            return Redirect("~/Asignacion");
        }
    }
}