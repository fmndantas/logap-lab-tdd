#!/bin/sh

docker run --name logap_lab_tdd \
  -e "ACCEPT_EULA=Y" \
  -e "MSSQL_SA_PASSWORD=1q2w3e4r@#$" \
  -p 1433:1433 \
  -v sqlvolume_logap_lab_tdd:/var/opt/mssql \
  mcr.microsoft.com/mssql/server
