# Service.Terceros
Un ejemplo de un servicio desarrollado en .Net Version 9, se describe a continuacion las caracteristicas

Servicio Api, cuya responsabilidad es la de acceder y consumir peticiones a una api de tercero o externa.

Se implemento el patron (Clean Architecture)
Se aplica Principios SOLID
Se aplica Inyeccion de Dependencias (DI)

Servicio Api Externa de Muestra:  

	- https://www.swapi.tech/api/people

El diseño empleado consta de las siguientes capas que se mencionan a continuación:

Capa Principal Servicio - (Presenter):

	- La misma contiene el controlador.
	  
	  - PeopleController
	  - ResponseHttp ( Contiene un swich que segun el caso, devolvera un resultado )
	  
	- Tambien se encuentra alojado las clases, propias de configuraciones de ( App y Services ). La idea de realizarlo asi, fue de mantener segmentada, 
	  para mas entendimiento, las configuraciones requeridas, para esta Api Services. 
	  
	  - Extensiones :
	  
		- IApplicationBuildExtension ( clase Statica )
		- IServiceCollectionExtensions ( clase Statica, donde entre configuracion requeridas, se encuentra la config de HttpClient )
		- IInjectionsExtensions ( clase Statica )

Capa de Aplicación:

Se encuentra toda la estructura que se podrá utilizar, dentro de las otras capas, si así fuese necesario.
Dentro de esta capa, están alojados dentro de directorios, para un mayor ordenamiemto y disponibles lo siguiente:

		- Configurations
		- DTOs
		- Gateways ( Contiene la interfaz, responsable del metodo GetPeople)
		- Genérics
		- Interactors
			- PeopleInteractor
			- LogServicesInteractor ( Clase servicio, cuya responsabilidad unica es la del registros de LOGs en archivo .TXT )
			
		- Interfaces
			- IPeopleInteractor
			- ILogServicesInteractor
		
		- Mappers (Se emplea Automapper)
		- Resources ( Se emplea archivo recurso, para el contenido de los mensajes, que se puedan producir durante la ejecución del flujo )
		- Responses ( Clases creadas de tipo Genericas, para estandarizar, lo ma optimo posible, la salida a respuestas de las solicitudes de cada endponit )
		
Capa Servicios: 
	
	- Se encuentra la clase "Servicio People", donde su responsabilidad, consta de establecer comunicacion al SERVICIO Tercero o Externo
	  mediante el empleo de ( IHttpClienteFactory ). Aqui se implementa su correspondiente Interfaz llamada ( IPeopleGateway )


  Nota: Como una simple aclaracion, es tan solo un simple ejemplo, de una forma de muchas existentes, para realizar este desarrollo. 
		Es tan solo a modo de ejemplo

  Saludos.! Gracias

