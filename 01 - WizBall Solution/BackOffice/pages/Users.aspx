<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="BackOffice.pages.Users" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>WizBall - Users</title>
    <link rel="shortcut icon" type="image/x-icon" href="~/resources/imgs/icon.ico" />
    <link href="~/styling/bootstrap/bootstrap.min.css" rel="stylesheet" />
    <link href="~/styling/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="~/styling/css/style.css" rel="stylesheet" />
    <link href="~/styling/css/estilos.css" rel="stylesheet" />
</head>
<body class="top-navigation">

	
	<!-- top navigation bar -->
	<nav class="navbar navbar-inverse navbar-fixed-top">
		<div class="container-fluid">
			<div class="navbar-header">
				<a class="navbar-brand" href="#">
					<img src="img/refood2.png" />
				</a>
			</div>  			
			<button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
				<span class="sr-only">Toggle navigation</span>
				<span class="icon-bar"></span>
				<span class="icon-bar"></span>
				<span class="icon-bar"></span>
			</button>
			<div id="navbar" class="collapse navbar-collapse">
				<ul class="nav navbar-nav">
					<li><a href="">PAINEL DE CONTROLO</a></li>
					<li><a href="nucleos.html">NÚCLEOS</a></li>
					<li><a href="fontes.html">FONTES</a></li>
					<li class="active"><a>VOLUNTÁRIOS</a></li>
					<li><a href="beneficiarios.html">BENEFICIÁRIOS</a></li>
					<li><a href="produtos.html">PRODUTOS</a></li>
				</ul>
				<ul class="nav navbar-nav navbar-right">
					<!--<li><a href=""><i class="glyphicon glyphicon-bell"></i></a></li>-->
					<li class="dropdown">
						<a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
							<span class="avatar avatar-online">
								<img src="img/profile/5788e6528978f.jpeg" />
							</span>
							Ana Figueiredo <span class="caret"></span>
						</a>
						<ul class="dropdown-menu">
							<li><a href="#">O meu perfil</a></li>
							<li><a href="#">Terminar sessão</a></li>
						</ul>
					</li>
				</ul>
			</div><!--/.nav-collapse -->
		</div>
	</nav>
	<!-- / top navigation bar -->


	<div id="st-container" class="st-container">

		<!-- lateral form add/edit -->
		<div class="st-menu st-effect-1" id="menu-1">
			<form class="row" id="form_registarRefood" name="form_registarRefood" method="post" class="form-horizontal">

				<!--para display de erro em browsers notHTML5
				<div id="mensagemErro" class="form-fonte alert alert-danger" role="alert" style="display:none">
					<span class="glyphicon glyphicon-exclamation-sign" aria-hidden="false"></span>
					<span class="sr-only">Erro:</span>
					<span class="msg"></span>
				</div>-->

				<!-- para "tipo" not displayed 
				<div class="form-group" style="display: none">
					<label class="col-sm-2 control-label">Tipo</label>
					<div class="col-sm-10">
						<input name="tipo" value="I" class="" type="text">
					</div>
				</div>-->

				<div class="col-lg-12">
					<h4>Adicionar voluntário</h4>
				</div>
						
				<div class="col-lg-3">
					<div class="image-upload">
					    <label for="photo">
					        <img src="img/avatar.png"/>
					    </label>

					    <input id="photo" name="photo" type="file"/>
					</div>
				</div>
				<div class="col-lg-9">
					<div class="col-lg-12">
						<label for="nomeRefood">Nome</label><br>
						<input id="nomeRefood" name="nomeRefood" value="" required="" type="text">
					</div>
					<div class="col-lg-4">
						<label for="nomeRefood">Username</label><br>
						<input id="nomeRefood" name="nomeRefood" value="" required="" type="text">
					</div>
					<div class="col-lg-8">
						<label for="dataNascimento">Data de nascimento</label><br>
						<input id="dataNascimento" name="dataNascimento" value="" required="" type="date">
					</div>
					<div class="col-lg-3">
						<label for="codPostal">Código Postal</label><br>
						<select id="codPostal" name="codPostal" title="Digite o código-postal" class="selectpicker " data-live-search="true">
	                    </select>
					</div>
					<div class="col-lg-9">
						<label for="rua">Morada</label><br>
	                    <select id="ruas" name="rua" title="Escolhe a rua" class="selectpicker " data-live-search="true">
	                    </select>
					</div>
					<div class="col-lg-6">
						<label for="localidade">Localidade</label><br>
						 <input id="localidade" name="localidade" class="" required="" type="text" disabled>
					</div>
					<div class="col-lg-6">
					 	<label for="porta">Nº da Porta</label>
	                    <input id="porta" name="porta" class="" required="" type="text">
					</div>

					<div class="col-lg-12">
						<label for="email">Contacto</label><br>
						<input id="contactinput"  name="" type="text" style="width:50%" />
						<select id="contactype" class="selectpicker" name="" style="width:40%">
		                    <!--{% for contact in typecontacts %}
		                        <option value="{{ contact.getId() }}">{{ contact.getName() }}</option>
		                    {% endfor %}-->
		                    <option>Telefone</option>
							<option>Telemóvel</option>
							<option>Email</option>
		                </select>
						<button id="newcontact" class="btn-primary no-border"><i class="glyphicon glyphicon-plus"></i></button>
					</div>		
					<div class="col-lg-12" style="margin-top:10px">
						<input id="" name="" type="text"  value="938879854" style="width:50%" />
						<select id="" class="selectpicker" name="" style="width:40%">
							<option>Telefone</option>
							<option selected>Telemóvel</option>
							<option>Email</option>
						</select>
						<button class="no-border"><i class="glyphicon glyphicon-minus" style="color:white"></i></button>
					</div>

					

					<div class="col-lg-6">
						<label for="tipoCargo">cargo</label><br>
						<select id="tipoCargo" class="selectpicker" name="tipoCargo" required="">
							<option value="1"> Responsável Voluntarios</option>
							<option value="2"> Responsável  Beneficiarios</option>
							<option value="3"> Responsável Fontes</option>
							<option value="4"> Administrador da Refood</option>
							<option value="5"> Administrador de Sistema</option>
							<option value="6"> Voluntário</option>
						</select>
					</div>
					<div class="col-lg-6">
						<label for="nomeRefood">Núcleo</label><br>
						<select id="nomeRefood" class="selectpicker" name="nomeRefood"></select>
					</div>
						
					<div class="col-lg-12 clearfix"></div>
					<div class="col-lg-6 st-menu-buttons">
						<button name="cancelar" class="btn btn-default" type="button">Cancelar</button>
					</div>
					<div class="col-lg-6 st-menu-buttons">
						<button name="guardar" class="btn btn-primary" type="button" onclick="validateForm(\'form_registarRefood\', \'site\', \'Núcleo inserido com sucesso\')">Guardar </button>
					</div>
				</div>
				
			</form>
		</div>
		<!-- / lateral form - add/edit -->


		<!-- conteudo central -->
		<div class="st-pusher">
			<div class="st-content">
				<div class="head-container">

					<!-- title -->
					<h3>Voluntários</h3>

					<div class="row">
						<div class="col-lg-6 col-xs-12">
							<p class="select-actions">
								<!-- Action list: active if any checkbox is checked -->
								<select class="selectpicker" style="">
									<option disabled selected>Ações em massa</option>
									<option>Exportar</option>
									<option>Remover</option>
								</select>
								<button class="btn btn-primary btn-sm">Ok</button>
								<!-- / action list -->

								<!-- Order by -->
								<span class="sort-by">
									Ordenar por
									<select class="selectpicker">
										<option>Mais recentes</option>
										<option>Mais Antigos</option>
									</select>
								<button class="btn btn-primary btn-sm">Ok</button>
								</span>
								<!-- / order by -->
							</p>
						</div>
						<div class="col-lg-6 col-xs-12 text-right">
							<p id="st-trigger-effects">
								<!-- search by -->
								<span class="search-by">
									<input type="text" name="" placeholder="Pesquisar por palavra(s) chave" />
									<select class="no-border selectpicker">
										<option>Tudo</option>
										<option>Nome</option>
										<option>Nascimento</option>
										<option>Endereço</option>
										<option>Contactos</option>
										<option>Cargo</option>
										<option>Núcleo</option>
									</select> &nbsp;
									<button class="btn-clean"><i class="glyphicon glyphicon-search"></i></button>
								</span>
								<!-- / search by -->

								<!-- add new instance -->
								<button data-effect="st-effect-1" class="btn btn-primary btn-sm">+ Adicionar voluntário</button>
							</p>
						</div>
					</div>

				</div>

				<div class="body-container">
					<div class="row">
						<div class="col-lg-12">

							<div class="content table-full-width" style="position:relative;">
								<!-- list/table-->	  			
								<table class="table table-hover">
									<thead>
										<tr>
											<th><input type="checkbox" /></th>
											<th><a class="order-by-desc" href="">Nome <i class="glyphicon glyphicon-chevron-down"></i></a></th>
											<th><a class="order-by-desc" href="">Data de nascimento <i class="glyphicon glyphicon-chevron-down"></i></a></th>
											<th><a class="order-by-desc" href="">Endereço <i class="glyphicon glyphicon-chevron-down"></i></a></th>
											<th><a class="order-by-desc" href="">Contactos <i class="glyphicon glyphicon-chevron-down"></i></a></th>
											<th><a class="order-by-desc" href="">Cargo <i class="glyphicon glyphicon-chevron-down"></i></a></th>
											<th><a class="order-by-desc" href="">Núcleo <i class="glyphicon glyphicon-chevron-down"></i></a></th>
											<th></th>
											<th></th>
										</tr>		
									</thead>
									<tbody>
										<tr>
											<td><input type="checkbox" /></td>
											<td>
												<span class="avatar avatar-online">
													<img src="img/profile/5788e6528978f.jpeg" />
												</span> Pedro Cabral
											</td>
											<td>
												02/09/1990
											</td>	
											<td>
												Rua Burgal de Baixo s/ número
												4150-157 Porto
											</td>
											<td>
												932264747
												fozdodouro.refood@gmail.com
											</td>
											<td>
												Foz do Douro
											</td>
											<td>
												Responsável Voluntários
											</td>
											<td>
												<a class="btn-clean" href=""><i class="glyphicon glyphicon-pencil"></i></a>
											</td>
											<td>
												<a class="btn-clean" href=""><i class="glyphicon glyphicon-trash"></i></a>
											</td>	
										</tr>
									</tbody>
								</table>
								<!-- / list/table-->
								<!-- pagination buttons -->
								<div class="col-lg-6 col-xs-12">
									<p class="table-footer">
										<a href=""><i class="glyphicon glyphicon-refresh"></i></a>
										<span class="pagination">
											(1-60 de 333) 
										</span>
										<span class="show-items">	 
											Itens por página
											<select class="selectpicker">
												<option>10</option>
												<option>30</option>
												<option>50</option>
												<option>100</option>
											</select>
										</span>		  			
									</p>
								</div>
								<div class="col-lg-6 col-xs-12 text-right">
									<p class="table-footer">		  				
										<span class="pagination-buttons">
											<a class="disabled" href=""><i class="glyphicon glyphicon-step-backward"></i></a>
											<a href=""><i class="glyphicon glyphicon-chevron-left"></i></a>
											<input type="text" value="1" />
											&nbsp; / &nbsp; 65
											<a href=""><i class="glyphicon glyphicon-chevron-right"></i></a>
											<a href=""><i class="glyphicon lyphicon glyphicon-step-forward"></i></a>
										</span>		
									</p>
								</div>	
								<!-- / pagination buttons -->
							</div>

						</div>
					</div>		
				</div>
			</div>
		</div>
		<!-- / conteudo central -->

	</div>

    <script src="/js/jquery/jquery.min.js"></script>
    <script src="/js/users.js"></script>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>

</body>
</html>
