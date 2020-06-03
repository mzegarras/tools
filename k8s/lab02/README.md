
docker run -p 7070:7070 mzegarra/customer:1.0.0

```
kubectl apply -f lab01.yaml
kubectl port-forward service/customers 7070:7070
curl -v http://localhost:7070/customers
```

kubectl run -i --tty shell --image=ubuntu /bin/sh
apt-get update
apt-get install -y curl
apt-get install -y dnsutils
apt-get install -y siege

Service validate
=======================

nslookup kubernetes.default
nslookup customers
nslookup customers.default


cat /etc/resolv.conf
======================
kubectl create ns qa
kubectl create ns prd
kubectl create ns dev

====================
kubectl get pods -n dev
kubectl get svc -n dev

nslookup customers.dev
nslookup customers.qa
====================

siege -r 2 -c 20 -d 1  -v "http://customers.default:7070/customers"
siege -r 2 -c 20 -d 1  -v "http://customers.default.svc.cluster.local:7070/customers"
siege -r 2 -c 20 -d 1  -v "http://customers.dev.svc.cluster.local:7070/customers"

====================





kubectl create configmap confnginx --from-file=./proxy/nginx.conf

