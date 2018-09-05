#!/bin/bash

#set github account
githubaccount="dejanstojanovic"
githubrepository="dotnetcore-windows-linux-service"
gitbranch="single-library"

#cleanup folders
sudo rm $githubrepository -r


#pull from github
git clone  https://github.com/$githubaccount/$githubrepository.git
cd ./dotnetcore-windows-linux-service
git checkout $gitbranch
cd ./Sample.Service


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

