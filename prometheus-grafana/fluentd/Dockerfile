# fluentd/Dockerfile

FROM fluent/fluentd:v1.17.0-debian-1.0
USER root
RUN ["gem", "install", "fluent-plugin-prometheus", "--no-document"]
USER fluent