# NginxConfigTransformer
Transform the distributed Nginx configuraiton files into a single one

# Dependency
Nginx Crossplane: https://github.com/nginxinc/crossplane

# How to use?

## Install Nginx Crossplane

You can install both the command line
interface and Python module via:

    pip install crossplane

## Generate Nginx configuration JSON schema from the source server

Run:

    crossplane parse --indent 4 --out <OutputFileName> <NginxConfigFileName>

Example:

    crossplane parse --indent 4 --out nginx-conf.json /etc/nginx/nginx.conf

## Merge JSON schema using NginxConfigTransformer

Run:

    NginxConfigTransformer --in <OriginalNginxConfigJsonSchema> --out <MergedNginxConfigJsonSchema>

Example:

    NginxConfigTransformer --in nginx-conf.json --out nginx-conf-merged.json

## Generate the merged Nginx configuration on the destination server

Copy the merged Nginx configuration JSON schema to the destination server with Nginx Crossplane installed.

Run:

    crossplane build --indent 4 --dir <NginxConfigFolder> <MergedNginxConfigJsonSchema>
    
Example:

    crossplane build --indent 4 --dir /etc/nginx nginx-conf-merged.json

