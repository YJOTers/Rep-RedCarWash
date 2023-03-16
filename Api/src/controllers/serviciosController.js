'use strict'
const util = require('util');
const connection = require('../bd/db');
const query = util.promisify(connection.query).bind(connection);

//Seleccionar servicio
const seleccionar_servicios = async function(req, res){
    const ide = req.params.ide;
    const sql = `SELECT * FROM vista_servicios WHERE id_uc_servicios = ${connection.escape(ide)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}
//Actualizar servicio
const actualizar_servicios = async function(req, res){
    const id = req.params.id;
    const sql = `UPDATE servicios SET ${connection.escape(req.body)} WHERE id_servicios = ${connection.escape(id)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}
//Insertar servicio
const insertar_servicios = async function(req, res){
    const sql = `INSERT INTO servicios SET ${connection.escape(req.body)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}
//Eliminar servicio
const eliminar_servicios = async function(req, res){
    const id = req.params.id;
    const sql = `DELETE FROM servicios WHERE id_servicios = ${connection.escape(id)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}

module.exports = {
    seleccionar_servicios,
    actualizar_servicios,
    insertar_servicios,
    eliminar_servicios
};