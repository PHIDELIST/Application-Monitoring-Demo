 1. Collecting Docker logs and propagating them to EFK (Elasticsearch + Fluentd + Kibana)
    
    This is a setup of [Fluentd](https://www.fluentd.org/) a logs collector that collects docker logs then send them to elastic search.
    
    To test it:
    
       +  ```cd fluentd-elasticsearch ```
       +  Then run ```docker compose up``` : this will spin up kibana, fluentd and a sample apache web server.
    The screenshot is a sample apache web server logs collected and sent to elastic search.
![image](https://github.com/PHIDELIST/Docker-Fluentd-Elasticsearch-kibana/assets/64526896/417a5738-91a1-4028-ad93-f3f009e99940)
 
2. Collecting .NET application logs using Prometheus:
   
   This is a setup to instrument dotnet application using [prometheus](https://prometheus.io/) then send logs to grafana for visualization.
   
   To test it:
    + run ```cd prometheus-grafana```
    + Then ```docker compose up```
    + Then start the dotnet application you want to collect its logs:
        + ```cd dotnet-api```
        + ```dotnet build```
        + ```dotnet run```
   
   ***Prometheus board***
![image](https://github.com/PHIDELIST/DockerLogsCollector/assets/64526896/c8a7783f-dd17-4e45-b42c-7442d44a3983)

   ***Grafana Board***
![image](https://github.com/PHIDELIST/DockerLogsCollector/assets/64526896/b38afab8-7286-4c16-a6e0-f706ae2b4b6a)


