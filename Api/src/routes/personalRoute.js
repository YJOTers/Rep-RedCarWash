'use strict'
const { Router } = require('express');
const api = Router();
var personalController = require('../controllers/personalController');

api.get('/seleccionar_personal/:ide', personalController.seleccionar_personal);
api.put('/actualizar_personal/:id', personalController.actualizar_personal);
api.post('/insertar_personal/', personalController.insertar_personal);
api.delete('/eliminar_personal/:id', personalController.eliminar_personal);

module.exports = api;