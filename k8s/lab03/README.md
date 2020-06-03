

kubectl create configmap confnginx --from-file=./proxy/nginx.conf


kubectl scale deployments/backend --replicas=4

fortio load -c 100 -qps 0 -n 1000 -loglevel Warning http://35.189.168.240:8080/programs

siege -r 20 -c 20 -d 1  -v --content-type 'application/json' "http://35.189.168.240:8080/programs POST {
    \"nombre_copy\": \"SRMR031\",
	\"programa\": \"SRMR031 <br/> Llamado por el program BSEOICS\",
	\"funcionalidad\": \"Consultas de datos del Cliente\",
	\"entrada\": \"Código Unico  ó <br/> Tipo Documento <br/> Número Documento\",
	\"salida\": \"<ul><li>Datos de Clientes Personas<ul><li>Datos Personales</li><li>Datos de Empleos</li></ul></li><li>Datos de Clientes Comerciales<ul><li>Datos de la Empresa </li> <li>Datos Comerciales</li> </ul></li> <li>Datos de Contacto <ul><li>Dirección</li><li>Email (emaper, emajob)</li><li>Teléfono (Trabajo, Residencia, Celular, Negocio, Fax)</li></ul></li></ul>\",
	\"bus_codigo\": \"A0001 <br/> A0001 <br/> A0309\",
	\"bus_version\": \"v1.0 <br/> v2.0 <br/> v1.0\",
	\"bus_framework\": \"F4 <br/> F4 <br/> F4\",
	\"bus_identificador\": \"cliente.consultarCliente\",
	\"api\": \"customer\"
}"
