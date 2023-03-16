'use strict'
const util = require('util');
const connection = require('../bd/db');
const query = util.promisify(connection.query).bind(connection);

//Seleccionar marca de vehiculo
const seleccionar_marcaDeVehiculo = async function(req, res){
    const ide = req.params.ide
    const sql = `SELECT * FROM marca WHERE id_uc_marca = ${connection.escape(ide)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}
//Actualizar marca de vehiculo
const actualizar_marcaDeVehiculo = async function(req, res){
    const id = req.params.id;
    const sql = `UPDATE marca SET ${connection.escape(req.body)} WHERE id_marca = ${connection.escape(id)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}
//Insertar marca de vehiculo
const insertar_marcaDeVehiculo = async function(req, res){
    const sql = `INSERT INTO marca SET ${connection.escape(req.body)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}
//Eliminar marca de vehiculo
const eliminar_marcaDeVehiculo = async function(req, res){
    const id = req.params.id;
    const sql = `DELETE FROM marca WHERE id_marca = ${connection.escape(id)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}

module.exports = {
    seleccionar_marcaDeVehiculo,
    actualizar_marcaDeVehiculo,
    insertar_marcaDeVehiculo,
    eliminar_marcaDeVehiculo
};