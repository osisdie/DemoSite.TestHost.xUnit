#================================================================
# About API
#================================================================
# - Document  
#   - Debug         http://localhost:5000/swagger
# - HealthCheck 
#   - Debug         http://localhost:5000/health


#!/bin/bash
#================================================================
# Variables
#================================================================
SERVICE_NAME=demosite-debug
VERSION=1.0.0.0
TAG=${SERVICE_NAME}:${VERSION}

for i in {\
VERSION,SERVICE_NAME,TAG\
}; do
  echo "$i = ${!i}"
done


#================================================================
# docker commands
#================================================================
docker build . -t $TAG -f Dockerfile
docker run -it --rm -p 5000:80 -p 5001:443 -e ASPNETCORE_ENVIRONMENT=Development -e ASPNETCORE_HTTPS_PORT=https://+:5001 -e ASPNETCORE_URLS=http://+:5000 --name rm-${SERVICE_NAME} ${TAG}
