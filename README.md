# Esys.Vendas

Projeto que simula um microservico de um e-commerce que cuidaria da parte de vendas

para executar o projeto precisa ter docker e kubernetes instalados na maquina.

executar script "StartProjectInKubernetes.bat" ira gerar as seguintes açoes:
-build da imagem docker
-criar configmap
-criar recursos NodePort para aplicação e banco de dados
-criar pods da aplicação e do banco de dados

apos isso , basta pegar a porta external do nodeport da aplicação atraves do comando kubectl get services e acessar
localhost:{porta externa do nodeport da aplicação}
