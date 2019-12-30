

let usersModalComponent = {
	template:
		`<div id="users_modal" class="modal fade in">\
			<div class="modal-dialog">\
				<div class="modal-content">\
					<div class="modal-header">\
						<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>\
						<h4 class="modal-title">{{modalTitle}}</h4>\
					</div>\
					<div class="modal-body">\
						<div class="row">\
							<div class="col-md-12">\
								<label for="name">Nome</label>\
							</div>\
						</div>\
						<div class="row">\
							<div class="col-md-6">\
								<label for="username">Username</label>\
								<input name="username" v-model="user.username" class="form-control" type="text" />\
							</div>\
							<div class="col-md-6">\
								<label for="email">Email</label>\
								<input name="email" v-model="user.email" class="form-control" type="email" />\
							</div>\
						</div>\
						<div class="row">\
							<div class="col-md-12">\
								<label for="rolesId">Acesso</label>\
								<roles-select v-model="user.rolesId" @change="rolesChanged"></roles-select>\
							</div>\
						</div>\
						<div class="row">\
							<div class="col-md-12">\
								<label for="observations">Observações</label>\
								<textarea class="form-control" v-model="user.observations"></textarea>\
							</div>\
						</div>\
					</div>\
					<div class="modal-footer">\
						<button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>\
						<button type="button" class="btn btn-primary" @click="associationSelected">Selecionar</button>\
					</div>\
				</div>\
			</div>\
		</div>`,

	components: {
		'roles-select': rolesSelectComponent
	},

	props: {
		user: Object,
		modalTitle: String
	},

	data: function () {
		return {
			name: null,
			username: null,
			password: null,
			roleId: null,
			observations: null
		}
	},

	methods: {
		rolesChanged: function (id) {
			this.rolesId = id;
		},

		roleSelected: function () {
			this.$emit('role-selected', this.roleId);
		}
	},

	created: function () {
		
	}
}