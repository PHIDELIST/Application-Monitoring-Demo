# fluentd/Dockerfile

FROM fluent/fluentd:v1.17.0-debian-1.0
USER root
RUN ["gem", "install", "fluent-plugin-opensearch", "--no-document"]
USER fluent