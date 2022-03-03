# Paquetería - API con ASP .NET 5.0
## Descripción de la API
Se ha implementado una aplicación para rastrear en tiempo real dónde se encuentran los pedidos realizados por los clientes.
Se divide en 2 niveles
- **Nivel 1: Funcionamiento básico de CRUD** 
  - La aplicación se divide en 4 capas: 
    - Modelo
    - Repository
    - Services
    - Controller
  - Se ha llevado a cabo la implementación de CRUD sobre el modelo que consta de las siguientes entidades
    -   Client
    -   Carrier
    -   Delivery
    -   Order
    -   LocationHistory
    -   Vehicle
  

    
- **Nivel 2: Proporcionar en tiempo real la ubicación del pedido a través de MQTT/WebHooks**. En este caso, se ha utilizado MQTT (MQ Telemetry Transport), en el que 
  primero se lanza un Subscriber el cual está constantemente en escucha. Posteriormente, cuando se realiza una modificación sobre la ubicación de un vehículo, el Publisher se conecta y
  manda el mensaje con los datos actualizados.



Por último, para securizar la aplicación se ha utilizado token JWT que se genera cuando un usuario hace login.

## Uso de la API
Se ha utilizado Docker para levantar la BBDD y la aplicación. (Docker con contenedores Linux)
- Para probar la API, tenemos que abrir la consola PowerShell como administrador. Nos movemos al directorio donde se encuentra el fichero *docker-compose.yml* y lanzamos 
el comando *docker-compose up*
- Se ha proporcionado un collection para Postman para poder probar el funcionamiento.
- Al securizar la aplicación, cada vez que lanzamos una petición para hacer *Login* se genera un token. Este token se guarda como variable de entorno en el propio Postman
  para poder lanzar el resto de peticiones.
- **NOTA** Para un correcto funcionamiento, primero se debe realizar una petición de *Register* y posteriormente hacer *Login* con el usuario registrado.
- Se proporciona una interfaz básica con todas las peticiones documentadas, accediendo a [Swagger](http://localhost:8080/swagger/index.html).

## Mejoras
- Validaciones para control de errores, por ejemplo: que no se pueda realizar un pedido si no se asigna un cliente existente.
- Incluir roles para los distintos usuarios.
