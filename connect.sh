#!/bin/bash

#change PREFIX to fdac-yourid
PREFIX=fdac22-audris
docker-machine start $PREFIX-1
IP=$(docker-machine ip $PREFIX-1)
docker-machine ssh $PREFIX-1 "sudo docker start $PREFIX"
ssh -p443 -i id_rsa_gcloud -oStrictHostKeyChecking=no -oUserKnownHostsFile=/dev/null \
 -L8889:localhost:8888 \
 -R27017:da1.eecs.utk.edu:27017 \
  jovyan@$IP

