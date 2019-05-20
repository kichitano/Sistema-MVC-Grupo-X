## Comandos git 
>"(_Tambien pueden usar un git gui como [git gui](https://git-scm.com/download/gui/windows) o [fork](https://git-fork.com/)_)"
tienen que estar en la solución. 
    ```
    cd ~/proyectou1/
    ```

#### Git configuración global.
    ```
    git config --global user.name "nombre"
    git config --global user.email "correo@gmail.com"
    ```

#### Guardar cambios del proyecto.
    ```
    git add .
    git commit -m "cambio "
    ```

#### Crear rama para hacer cambios.
    ```
    git checkout -b "rama_nombre_de_funcionalidad"
    ```

#### Ver en que rama estan.
    ```
    git branch
    ```

#### Subir cambios.
    ```
    git pull origin rama_nombre_de_funcionalidad
    git push origin rama_nombre_de_funcionalidad
    ```
    Si no existe cambios guardados hacer defrente 
    git push origin rama_nombre_de_funcionalidad
#### Revertir cambios 
    ```
    git pull origin rama_nombre_de_funcionalidad
    git revert HEAD
    git push origin rama_nombre_de_funcionalidad
    ```

#### Mezclar ramas.
    ```
    git checkout master
    git merge rama_nombre_de_funcionalidad
    ```

#### Cambiar de rama.
    ```
    git checkout rama
    ```

