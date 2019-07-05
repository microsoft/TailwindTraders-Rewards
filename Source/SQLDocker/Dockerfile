FROM microsoft/mssql-server-windows-developer:2017-latest as build
ENV attach_dbs='[{"dbName":"rewardsdb","dbFiles":["C:\\rewardsdb.mdf","C:\\rewardsdb_log.ldf"]}]'
COPY ./rewardsdb.mdf .
COPY ./rewardsdb_log.ldf .