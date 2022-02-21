# PawPalsApp

[Puedes acceder a la documentación más detallada aquí](https://asanchezbdam1.github.io/PawPalsApp/)

## PawPalsApp

Contiene la parte de la aplicación hecha en Xamarin.

### PawPalsApp Views

Contiene las vistas de la aplicación. Cada pantalla tiene su propio XAML. El código de funcionamiento está hecho en C#. El texto de la página está guardado como recurso en Resx para soportar múltiples idiomas. Las pantallas son:

- Account: Información de la cuenta de usuario.
- Care: Administración del cuidado de las mascotas.
- CuteOMeter: Red social de la aplicación.
- Guide: Guía con consejos de cuidado de mascotas.
- Login: Pantalla de inicio de sesión de usuario.
- PaginaMenu: Menú inferior de la aplicación.
- Register: Pantalla de registro de usuarios.
- Settings: Ajustes de la aplicación con dos sub apartados:
  - SettingsAccount: Ajustes de la cuenta con la que se ha iniciado sesión.
  - SettingsInfo: Información de la aplicación.
- Welcome: Pantalla de bienvenida.

### PawPalsApp Resx

Carpeta con archivos de recursos. Son diccionarios de recursos que contienen los textos en los idiomas disponibles. Si el idioma del dispositivo no coincide con ninguno de los soportados, el idioma por defecto es el inglés.

### PawPalsApp Data

Clases de la capa de datos que permiten el acceso o guardado de información en la base de datos SQLite. Las clases son:

- SQLiteDieta: Para la gestión de Dieta.
- SQLiteEjercicio: Para la gestión de Ejercicios.
- SQLiteHigiene: Para la gestión de Higiene.
- SQLiteMascota: Para la gestión de Mascotas.

### PawPalsApp Classes

Clases de modelo y de apoyo de la aplicación móvil. Son:

- ByteArrayToImageConverter: Convierte la imagen en formato de array de bytes en una imagen reconocible por Xamarin.
- ConnectionHelper: Permite la conexión e intercambio de información entre cliente y servidor.
- Dieta: Modela una actividad de dieta de una mascota.
- Ejercicios: Modela una actividad de ejercicio de una mascota.
- FieldVerifier: Verifica que los campos introducidos son correctos.
- Higiene: Modela una actividad de higiene de una mascota.
- ImagePicker: Permite obtener una imagen del almacenamiento del teléfono.
- Mascotas: Modela una mascota del usuario.
- PostViewCollection: Representa una colección observable de publicaciones para mostrar y actualizar correctamente en la interfaz.

## PawPalsServer

Se encarga de la gestión de conexiones y solicitudes de clientes, conectando con la base de datos. Además del código principal del servidor, en PawPalsServer, hay dos bibliotecas de clases:

### ServerVerificators

Dado un objeto recibido por el servidor, comprueba de que tipo es y si es correcto. Devuelve la acción que debe realizar.

### ServerActions

Dada la acción comprobada, hace la tarea en la base de datos y le da una respuesta al servidor que enviar al cliente.

## CrossClasses

Son las clases intermedias entre el servidor y el cliente. Sirven para enviarse información entre ambos además de formar parte del modelo del cliente. Las clases son:

- ObjectSerializer: Permite la serialización o deserialización de objetos para su envío a través de la conexión TCP.
- Post: Representa una publicación de la red social.
- PostList: Representa una lista de publicaciones con información del usuario para solicitar la información correcta en el servidor.
- PostReacted: Es la reacción que un usuario ha tenido a una publicación. Se envía para que el servidor añada, cambie o borre la reacción del usuario a una publicación.
- PostReaction: Son las posibles reacciones que puede tener un usuario a una publicación. Tan solo contiene los posibles valores: Like, Dislike o None.
- PostReport: Se envía al servidor al reportarse una publicación con un motivo de una lista de motivos. No se elimina la publicación reportada al instante.
- User: Clase que modela a un usuario. Tiene sus datos. No se guarda la contraseña tras el inicio de sesión. Tiene los siguientes subtipos para realizar acciones en el servidor:
  - RegisterUser
  - LoginUser
  - UpdateUser
  - DeleteUser
