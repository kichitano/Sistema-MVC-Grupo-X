## Comandos git 
>"(_Tambien pueden usar un git gui como [git gui](https://git-scm.com/download/gui/windows) o [fork](https://git-fork.com/)_)"
tienen que estar en la solución. 
    ```
    cd ~/Sistema_MVC_Grupo_X/
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
    git pull origin rama_nombre_de_usuario
    git push origin rama_nombre_de_usuario
    ```
    Si no existe cambios guardados hacer defrente 
    git push origin rama_nombre_de_usuario
#### Revertir cambios 
    ```
    git pull origin rama_nombre_de_usuario
    git revert HEAD
    git push origin rama_nombre_de_usuario
    ```

#### Mezclar ramas.
    ```
    git checkout master
    git merge rama_nombre_de_usuario
    ```

#### Cambiar de rama.
    ```
    git checkout rama
    ```

