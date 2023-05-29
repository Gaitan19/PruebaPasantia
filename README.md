Descripci�n de la API REST para gesti�n de tareas
La API REST desarrollada es una aplicaci�n de gesti�n de tareas que permite listar, crear, editar y eliminar tareas, cumpliendo con los siguientes requisitos:

Autenticaci�n
La API utiliza autenticaci�n basada en tokens JWT (JSON Web Tokens). Esto garantiza que los usuarios deben autenticarse antes de acceder a los endpoints protegidos. La autenticaci�n se realiza mediante el intercambio seguro de tokens firmados, lo que proporciona una capa adicional de seguridad para proteger los datos de los usuarios.

Listado de tareas
La API ofrece un endpoint para listar las tareas existentes. Los usuarios autenticados pueden acceder a esta funcionalidad para obtener un listado completo de todas las tareas, incluyendo aquellas marcadas como eliminadas. Adem�s, se proporciona la opci�n de buscar una tarea espec�fica por su identificador �nico.

Creaci�n y edici�n de tareas
La API permite a los usuarios autenticados crear nuevas tareas mediante un endpoint dedicado. Al enviar los datos de la tarea, esta se guarda en la base de datos, asegurando la persistencia de la informaci�n. Adem�s, se ha implementado un endpoint para editar tareas existentes, permitiendo a los usuarios actualizar la informaci�n de una tarea espec�fica.

Eliminaci�n de tareas (Soft Delete)
La API ofrece la capacidad de eliminar tareas, utilizando un enfoque de "Soft Delete". Cuando se solicita la eliminaci�n de una tarea, esta se marca como eliminada en la base de datos, pero no se elimina f�sicamente. De esta manera, las tareas eliminadas permanecen registradas en la base de datos, pero se excluyen de las consultas de listado y b�squeda. Si una tarea marcada como eliminada se elimina nuevamente, se eliminar� permanentemente de la base de datos.

Persistencia de datos
La API utiliza una base de datos SQL Server para persistir los datos de las tareas. Al crear una tarea, editarla o eliminarla, los cambios se reflejan en la base de datos, asegurando que la informaci�n se mantenga de manera consistente.

Intrucciones
Descarga el proyecto desde el repositorio de GitHub

Configura la base de datos:

Abre SQL Server Management Studio y conecta a tu instancia de SQL Server.
Crea una nueva base de datos para la API REST.
Ejecuta el script SQL provisto en el proyecto ) en la base de datos reci�n creada. Este script crear� la estructura de la base de datos y las tablas necesarias para almacenar las tareas.
Configura la cadena de conexi�n:

Abre el proyecto de la API REST en tu entorno de desarrollo Encuentra el archivo appsettings.json en la soluci�n del proyecto.
Reemplaza los valores de <SERVIDOR>, <BASE_DE_DATOS>, <USUARIO> y <CONTRASE�A> en la cadena de conexi�n dentro del archivo appsettings.json con la informaci�n correspondiente a tu base de datos reci�n configurada.
Compila y ejecuta el proyecto:

Compila el proyecto de la API REST en tu entorno de desarrollo para asegurarte de que no haya errores de compilaci�n.
Ejecuta el proyecto. La API REST estar� disponible en la URL especificada en tu entorno de desarrollo (por ejemplo, http://localhost:5000 o https://localhost:5001).
Utiliza la API REST:

Puedes utilizar los ejemplos de "Acciones.postman_collection" que proporcione para realizar las pruebas a la API REST
