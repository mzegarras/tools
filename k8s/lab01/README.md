Commandos:

az aks get-credentials --resource-group K8S-Taller --name lpsataller

kubectl get nodes

=====
curl -LO https://storage.googleapis.com/kubernetes-release/release/v1.11.0/bin/windows/amd64/kubectl.exe
====
docker run --name some-nginx -d -p 8080:80 nginx


1.- Crear pods
kubectl run my-nginx --image=nginx --replicas=2 --port=80
kubectl scale deployments/my-nginx --replicas=5

kubectl get pods
kubectl get deployment

2.- Crear service
kubectl expose deployment my-nginx --port=80 --type=LoadBalancer
kubectl expose deployment my-nginx --port=80 --type=Cluster

3.- Eliminar service
kubectl delete service my-nginx
kubectl delete deployment my-nginx



4.- Generar imagen:

docker build -t lpsa:1.0 .
docker build -t lpsa:2.0 .

5.- Angular
npm install
ng serve

6.-
docker run -p 8080:80 lpsa:1.0
docker run -p 8080:80 lpsa:2.0

7.- Publicar docker hub
docker tag lpsa:1.0 mzegarra/lpsa:1.0
docker tag lpsa:2.0 mzegarra/lpsa:2.0

docker push mzegarra/lpsa:1.0
docker push mzegarra/lpsa:2.0

- Ejemplo kubernetes
kubectl create deployment lpsa --image mzegarra/lpsa:1.0
kubectl scale deployments/lpsa --replicas=5
kubectl expose deployments lpsa --port=80 --type=LoadBalancer
kubectl expose deployments lpsa --port=80 --type=Cluster

---Actualizar

kubectl set image deployments/lpsa lpsa=mzegarra/lpsa:2.0

--Commit
kubectl rollout status deployments/lpsa

--Rollback
kubectl rollout undo deployments/lpsa