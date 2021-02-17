# Operación Fuego de Quasar
Este proyecto se desarrolla con el fin de solucionar el reto técnico para ser parte del equipo de tecnología en **Mercado Libre**.

El objetivo principal es desarrollar una aplicación de servicios web REST Full que permita ubicar una nave espacial utilización la técnica de la **trilateración** a partir de 3 satélites de referencia. Mas información: [operación Fuego de Quasar](Documentation\Operacion-Fuego-de-Quasar.pdf)

## **Información General**
### Herramientas de desarrollo
* [ASP.NET](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-5.0)
* [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
* [XUnit](https://xunit.net/)
* [Swagger](https://swagger.io/)
### Herramientas de infraestructura
* [Azure App Service](https://azure.microsoft.com/es-es/services/app-service/)
* [Azure SQL Database](https://azure.microsoft.com/es-es/services/sql-database/)
### Herramientas de administración de proyecto
* [Azure DevOps](https://azure.microsoft.com/es-es/services/devops/)
* [Azure Pipelines](https://azure.microsoft.com/es-es/services/devops/pipelines/)

## **Ejecución Local**
* Se requiere el IDE [Visual Studio](https://visualstudio.microsoft.com/es/)
* **Configuración de la base de datos**
  * En el proyecto **MercadoLibre.OperacionQasar.DataBase** debe publicarse (Click Derecho, Publish..)
  ![Screenshot](https://github.com/AF-Moreno/OperacionQuasar/tree/main/Documentation/ScreenShots/Project-DataBase-Publish.png)
  * Seleccionar la conexión:
  ![Screenshot](Documentation\ScreenShots\Project-DataBase-Publish-Connections.png)
  * Debe conectarse a la base de datos creada y ejecutar el **Procedimiento Almacenado** **[dbo.StartApplication]**
  * En el proyecto **MercadoLibre.OperacionQasar.WebApp** en el archivo **appsettings.Development.json** debe especificar la cadena de conexion a la base de datos creada en la propiedad **ConnectionStrings.DefaultConnection**
* **Ejecución de la aplicación Web**
  * En **Visual Studio** se debe seleccionar el proyecto **MercadoLibre.OperacionQasar.WebApp** por defecto para ejecutar. Se recomienda seleccionar el servidor web **IIS Express**
  ![Screenshot](Documentation\ScreenShots\Project-WebApp-Execution.png)
* **Ejecución de pruebas Unitarias**
  * En la vista del **Explorador de Pruebas**  se ejecutan todas las pruebas
  ![Screenshot](Documentation\ScreenShots\Project-Test-Execution.png)

## **Arquitectura de Software**
Prácticas de desarrollo implementadas:
* [SOLID](https://es.wikipedia.org/wiki/SOLID)
* [Patrón Diseño guiado por el dominio (DDD)](https://es.wikipedia.org/wiki/Dise%C3%B1o_guiado_por_el_dominio)
* [Patrón Repository](https://our-academy.org/posts/el-patron-repository:-implementacion-y-buenas-practicas)
* [Patrón de inyección de dependencias](https://es.wikipedia.org/wiki/Inyecci%C3%B3n_de_dependencias)
* [Unit Testing](https://es.wikipedia.org/wiki/Prueba_unitaria)
### **Diagrama de Paquetes**
Se implementa la arquitectura MVC segregado por las siguientes capas

![Screenshot](Documentation\Diagrams\Export\PackagesDiagram.jpg)

**MercadoLibre.OperacionQasar.Core**
* **Repository** 
  * Capa encargada del acceso a Datos (SQL Server, MemoryCache)
  * implementación del patrón repositorio
* **Domain (Service)**
  * Implementa la lógica de negocio segregado por Dominios (servicios)
* **Utils**
	* Exponer clases con funciones útiles en cualquier parte del sistema
 
**MercadoLibre.OperacionQasar.WebApp**
* **Controller**
  *  Capa encargada de recibir todas las solicitudes **HTTP**
* **Authentication Filter**
  * Define Los filtros de autenticación para identificar el usuario el cual requiere de algún End-Point

**MercadoLibre.OperacionQasar.Test**
* **Unit**
  * Contenedor de las pruebas unitarias del sistema

## **Administración del proyecto**
Se implementa [Azure DevOps](https://azure.microsoft.com/es-es/services/devops/) para administrar el proyecto

![Screenshot](Documentation\ScreenShots\Azure-DevOps.png)

### **configuración**
* Service Connections
  * Conexión con el repositorio privado en **GitHub**
  * Conexión con la suscripción de **Azure**

![Screenshot](Documentation\ScreenShots\Azure-DevOps-Settings.png)

## **Infraestructura y despliegue**
El proyecto se despliega utilizando diferentes servicios del portal de **Azure**
Se requiere tener una suscripción activa en el portal de **Azure**

### **Diagrama de despliegue**
![DeploymentDiagram](https://user-images.githubusercontent.com/35159383/108166832-c0782e00-70c2-11eb-836d-12b14c147ae3.jpg)

* **Azure Server**
  Servidores de azure que provee el uso de los siguientes servicios:
  * **Resource Group:**
  Administra todos los recursos y servicios de infraestructura de nuestra aplicación
    * **Web App Service:**
    Servicio que permite el despliegue del API service
    * **Azure SQL Data Base Server**
    Servidor que aloja la base de datos usada por el API Service

  * **Azure DevOps Organization:**
  Plataforma que nos permite la administración del proyecto
    * **Operacion Qasar Project**
    Instancia que almacena toda la información del proyecto
      * **Azure Pipeline:**
      Servicio que permite la definición del Job para el despliegue de la aplicación. Se definen las tareas necesarias para realizar el despliegue de todos los componentes:
      ![Screenshot](Documentation\ScreenShots\Azure-DevOps-Pipeline.png)
      
        Éste se ejecuta de manera manual o después de que un **Pull Request** es aprobado en **GitHub:**
      ![Screenshot](Documentation\ScreenShots\Azure-DevOps-Pipeline-Trigger.png)

## **Características de la aplicación**
* Implementa **Swagger** el cual nos ofrece una interfaz grafica que permite el uso de los diferentes servicios directamente desde el **Navegador Web** https://operacion-fuego-qasar.azurewebsites.net/swagger/index.html
![Screenshot](Documentation\ScreenShots\Swagger-UI.png)
* **Autenticación**
  * Como aplicación productiva se requiere el uso de autenticación de usuarios, en este caso se implementa la autenticación _Basic_ el cual requiere de usuario y contraseña: 
    * Usuario: meli.admin@meli.com
    * Contraseña: Meli.2021
    * Credenciales codificadas en Base 64: bWVsaS5hZG1pbkBtZWxpLmNvbTpNZWxpLjIwMjE=
  * Utilizando la interfaz grafica de **Swagger** podemos realizar la autenticación (Botón 'Authorize'):
![Screenshot](Documentation\ScreenShots\Swagger-Authentication.png)

* **Servicios**
  * POST
    * https://operacion-fuego-qasar.azurewebsites.net/api/v1/satellite/topsecret
      * Recibe las distancias y mensajes emitidos por la nave.
      * Retorna la ubicación exacta de la nave junto con el mensaje descifrado. 
      
    * https://operacion-fuego-qasar.azurewebsites.net/api/v1/satellite/topsecret_split/{satellite_name}
      * Recibe la distancia y el mensaje a un solo satélite. Internamente es almacenado en la **Memoria Cache**
      * Retorna **true** si la información del satélite fue almacenada exitosamente
  * GET
    * https://operacion-fuego-qasar.azurewebsites.net/api/v1/satellite/topsecret_split/
      * Retorna la ubicación exacta de la nave junto con el mensaje descifrado siempre y cuando toda la información requerida allá sido previamente enviada al servidor
    * https://operacion-fuego-qasar.azurewebsites.net/api/v1/satellite/topsecret_split/{satellite_name}
      * Retorna la ubicación exacta de la nave junto con el mensaje descifrado siempre y cuando toda la información requerida allá sido previamente enviada al servidor

