# 1: Docker build

```
sudo docker build -f Dockerbuild1 -t web:1.0.0 .
docker run -p 8085:80 miguel:1.0.0

docker build -f Dockerbuild2 -t miguel:2.0.0 .
docker run -p 8085:8085 miguel:2.0.0

docker build . -t mjava:1.0.0
docker run -p 8085:8080 mjava:1.0.0

```

# 2: Add reference
```
https://www.nuget.org/packages/MySql.Data/
```

# 3: Generar binario


```
dotnet publish -c Release
dotnet publish -c Debug
```

# 4: Generar docker
```
docker-compose build
docker-compose up
docker-compose down
docker-compose rm
```

# 5: Add redis
```
dotnet add package Microsoft.Extensions.Caching.Redis --version 2.2.0
```
