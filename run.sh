#!/bin/bash
#curl -L https://github.com/docker/machine/releases/download/v0.12.2/docker-machine-`uname -s`-`uname -m` >docker-machine &&
#chmod +x docker-machine 

#change PREFIX to fdac-yourid
PREFIX=fdac22-audris
#Cloud instances can be run in various zones, each with a different geographic location
# Each zone may have its own type of machine type (we are using n1-standard-1)
ZONE=us-east1-b
MACHINE_TYPE=f1-micro
#n1-standard-1
#select the amount of space you need to temporarily store data on the machine
DISK_SIZE=20
#Get your project ID: it has to be configured as described in the README.md
PROJECT_ID=$(gcloud config list project |  awk 'FNR == 2 { print $3 }')


#First remove the machine if it already exists 
docker-machine rm -f $PREFIX-1
#Now start GC instance using docker-machine interface
docker-machine create -d google \
  --google-zone $ZONE \
  --google-project $PROJECT_ID \
  --google-machine-type $MACHINE_TYPE \
  --google-machine-image https://www.googleapis.com/compute/v1/projects/ubuntu-os-cloud/global/images/ubuntu-1604-xenial-v20170815a \
  --engine-install-url=https://releases.rancher.com/install-docker/17.05.sh \
  $PREFIX-1

#these are the environment variables that need to be set to work with the
#docker engine on that remote machine
# It makes sense only if docker engine runs on local host
#echo "eval $(docker-machine env $PREFIX-1)"
#now actually set these variables
#eval $(docker-machine env $PREFIX-1)


#The firewall prevents connecting to GC instances, open port 443
# Need to do it only once
gcloud compute firewall-rules create jup-ssh443 --allow tcp:443 --description="JupyterSSH"

#update to the latest versio of the container on the remote host
docker-machine ssh $PREFIX-1 "sudo docker pull audris/jupyter-r:latest"

#remove prior container on the remote host
docker-machine ssh $PREFIX-1 "sudo docker rm -f $PREFIX"

#run suitable container on the remote host
docker-machine ssh $PREFIX-1 "sudo docker run -id --name=$PREFIX -p443:22 -w /home/jovyan audris/jupyter-r:latest /bin/startDef.sh"

#obtain the IP of that instance
IP=$(docker-machine ip $PREFIX-1)

#make sure the private key is not readable
chmod og-rwx id_rsa_gcloud 
#create port-forwarding so that yu can interact with the notebook
#on the remote machine


ssh -p443 -i id_rsa_gcloud -oStrictHostKeyChecking=no -oUserKnownHostsFile=/dev/null \
  -L8889:localhost:8888 -R27017:da1.eecs.utk.edu:27017 jovyan@$IP

