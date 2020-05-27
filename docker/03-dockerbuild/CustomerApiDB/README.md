dotnet publish -c Release

https://www.nuget.org/packages/MySql.Data/

dotnet add package MySql.Data --version 8.0.16


https://www.nuget.org/packages/StackExchange.Redis/





# 5: Add referencia redis
```
dotnet add package Microsoft.Extensions.Caching.Redis --version 2.2.0
dotnet add remove Microsoft.Extensions.Caching.Redis
```


# 5: Read redis
```
docker exec -it c1537a79d247 /bin/sh
redis-cli
keys *

HGETALL appcachecustomer:6
```

```
/data # redis-cli
127.0.0.1:6379> AUTH password
```





#6: Publish subcribe
```
dotnet add package Apache.NMS.ActiveMQ.NetCore --version 1.7.2
```