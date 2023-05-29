Descripción de la API REST para gestión de tareas
La API REST desarrollada es una aplicación de gestión de tareas que permite listar, crear, editar y eliminar tareas, cumpliendo con los siguientes requisitos:

Autenticación
La API utiliza autenticación basada en tokens JWT (JSON Web Tokens). Esto garantiza que los usuarios deben autenticarse antes de acceder a los endpoints protegidos. La autenticación se realiza mediante el intercambio seguro de tokens firmados, lo que proporciona una capa adicional de seguridad para proteger los datos de los usuarios.

Listado de tareas
La API ofrece un endpoint para listar las tareas existentes. Los usuarios autenticados pueden acceder a esta funcionalidad para obtener un listado completo de todas las tareas, incluyendo aquellas marcadas como eliminadas. Además, se proporciona la opción de buscar una tarea específica por su identificador único.

Creación y edición de tareas
La API permite a los usuarios autenticados crear nuevas tareas mediante un endpoint dedicado. Al enviar los datos de la tarea, esta se guarda en la base de datos, asegurando la persistencia de la información. Además, se ha implementado un endpoint para editar tareas existentes, permitiendo a los usuarios actualizar la información de una tarea específica.

Eliminación de tareas (Soft Delete)
La API ofrece la capacidad de eliminar tareas, utilizando un enfoque de "Soft Delete". Cuando se solicita la eliminación de una tarea, esta se marca como eliminada en la base de datos, pero no se elimina físicamente. De esta manera, las tareas eliminadas permanecen registradas en la base de datos, pero se excluyen de las consultas de listado y búsqueda. Si una tarea marcada como eliminada se elimina nuevamente, se eliminará permanentemente de la base de datos.

Persistencia de datos
La API utiliza una base de datos SQL Server para persistir los datos de las tareas. Al crear una tarea, editarla o eliminarla, los cambios se reflejan en la base de datos, asegurando que la información se mantenga de manera consistente.

Intrucciones
Descarga el proyecto desde el repositorio de GitHub

Configura la base de datos:

Abre SQL Server Management Studio y conecta a tu instancia de SQL Server.
Crea una nueva base de datos para la API REST.
Ejecuta el script SQL provisto en el proyecto ) en la base de datos recién creada. Este script creará la estructura de la base de datos y las tablas necesarias para almacenar las tareas.
Configura la cadena de conexión:

Abre el proyecto de la API REST en tu entorno de desarrollo Encuentra el archivo appsettings.json en la solución del proyecto.
Reemplaza los valores de <SERVIDOR>, <BASE_DE_DATOS>, <USUARIO> y <CONTRASEÑA> en la cadena de conexión dentro del archivo appsettings.json con la información correspondiente a tu base de datos recién configurada.
Compila y ejecuta el proyecto:

Compila el proyecto de la API REST en tu entorno de desarrollo para asegurarte de que no haya errores de compilación.
Ejecuta el proyecto. La API REST estará disponible en la URL especificada en tu entorno de desarrollo (por ejemplo, http://localhost:5000 o https://localhost:5001).
Utiliza la API REST:

Puedes utilizar los ejemplos de "Acciones.postman_collection" que proporcione para realizar las pruebas a la API REST
