
# 1: Install Docker

Install needed packages:

```
sudo yum install -y yum-utils device-mapper-persistent-data lvm2
```

Configure the docker-ce repo:

```
$ sudo yum-config-manager --add-repo https://download.docker.com/linux/centos/docker-ce.repo
```

Install docker-ce:
```
$ sudo yum install docker-ce
```

Add your user to the docker group with the following command.
```
$ sudo usermod -aG docker $(whoami)
o
$ sudo usermod -aG docker $USER
```

Set Docker to start automatically at boot time:
```
$ sudo systemctl enable docker.service
```

Finally, start the Docker service:
```
$ sudo systemctl start docker.service
$ sudo chmod 666 /var/run/docker.sock
```

# 2: Install Docker Compose

Install Extra Packages for Enterprise Linux
```
$ sudo yum install epel-release
```

Install python-pip
```
$ sudo yum install -y python-pip
```

Then install Docker Compose:

```
$ sudo pip install docker-compose
```


You will also need to upgrade your Python packages on CentOS 7 to get docker-compose to run successfully:

```
$ sudo yum upgrade python*
```

To verify a successful Docker Compose installation, run:
```
docker-compose version
```

# 3:  Uninstall old versions
```
sudo yum remove docker \
                  docker-client \
                  docker-client-latest \
                  docker-common \
                  docker-latest \
                  docker-latest-logrotate \
                  docker-logrotate \
                  docker-engine
```                  
