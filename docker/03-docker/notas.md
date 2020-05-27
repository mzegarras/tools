# 1: Build container

```
docker logs #id2342
docker logs #id2342 -f
```

# 2: Conectarse container
```
docker exec -it id-container /bin/sh
cd /usr/share/nginx/html
echo "<html><h1>demo</h1></html>" >> demo.html
```
[Settings NGINX](https://docs.docker.com/samples/library/nginx/)


# 3: volumnes

```bash
docker run -p 8080:80 -v $PWD/nginx:/usr/share/nginx/html nginx:latest

docker run -v $PWD/mysql:/var/lib/mysql -e MYSQL_DATABASE=compras -e MYSQL_ROOT_PASSWORD=my-secret-pw -p 3306:3306 mysql:5.7
```

# 3: volumnes
```bash
docker inspect 718b76be7af7
```
