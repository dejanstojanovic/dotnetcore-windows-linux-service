#!/bin/bash

#set dockerhub account
dockeraccount="dejanstojanovic"
servicename="sampleservice"

#get timestamp for the tag
timestamp=$(date +%Y%m%d%H%M%S)

#build image
sudo docker build -t $servicename:$timestamp .

#remove dangling images
sudo docker system prune -f

#push to dockerhub
sudo docker login
#sudo docker login -u username -p password
sudo docker tag $servicename:$timestamp $dockeraccount/$servicename:$timestamp
sudo docker push $dockeraccount/$servicename:$timestamp

