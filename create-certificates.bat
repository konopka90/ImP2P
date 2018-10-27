if not exist "certs" mkdir "certs"

echo Generate CA key:
openssl genrsa -passout pass:1111 -des3 -out certs/ca.key 4096

echo Generate CA certificate:
openssl req -passin pass:1111 -new -x509 -days 365 -key certs/ca.key -out certs/ca.crt -subj  "/C=US/ST=CA/L=Cupertino/O=YourCompany/OU=YourApp/CN=MyRootCA"

echo Generate server key:
openssl genrsa -passout pass:1111 -des3 -out certs/server.key 4096

echo Generate server signing request:
openssl req -passin pass:1111 -new -key certs/server.key -out certs/server.csr -subj  "/C=US/ST=CA/L=Cupertino/O=YourCompany/OU=YourApp/CN=%COMPUTERNAME%"

echo Self-sign server certificate:
openssl x509 -req -passin pass:1111 -days 365 -in certs/server.csr -CA certs/ca.crt -CAkey certs/ca.key -set_serial 01 -out certs/server.crt

echo Remove passphrase from server key:
openssl rsa -passin pass:1111 -in certs/server.key -out certs/server.key

echo Generate client key
openssl genrsa -passout pass:1111 -des3 -out certs/client.key 4096

echo Generate client signing request:
openssl req -passin pass:1111 -new -key certs/client.key -out certs/client.csr -subj  "/C=US/ST=CA/L=Cupertino/O=YourCompany/OU=YourApp/CN=%COMPUTERNAME%"

echo Self-sign client certificate:
openssl x509 -passin pass:1111 -req -days 365 -in certs/client.csr -CA certs/ca.crt -CAkey certs/ca.key -set_serial 01 -out certs/client.crt

echo Remove passphrase from client key:
openssl rsa -passin pass:1111 -in certs/client.key -out certs/client.key