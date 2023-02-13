# Esys.Vendas

Projeto que simula um microservico de um e-commerce que cuidaria da parte de vendas

para executar o projeto precisa ter docker e kubernetes instalados na maquina.

executar script "StartProjectInKubernetes.bat" ira gerar as seguintes açoes:
-build da imagem docker
-criar configmap
-criar recursos NodePort para aplicação e banco de dados
-criar pods da aplicação e do banco de dados

Swagger: localhost:30007/swagger
(se estiver usando linux vai ter que pegar o IP do cluster. ex: ipcluster:30007/swagger)
