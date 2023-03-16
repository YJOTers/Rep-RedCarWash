'use strict'
const util = require('util');
const connection = require('../bd/db');
const query = util.promisify(connection.query).bind(connection);

//Seleccionar color de vehiculo
const seleccionar_colorDeVehiculo = async function(req, res){
    const ide = req.params.ide;
    const sql = `SELECT * FROM color WHERE id_uc_color = ${connection.escape(ide)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}
//Actualizar color de vehiculo
const actualizar_colorDeVehiculo = async function(req, res){
    const id = req.params.id;
    const sql = `UPDATE color SET ${connection.escape(req.body)} WHERE id_color = ${connection.escape(id)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}
//Insertar color de vehiculo
const insertar_colorDeVehiculo = async function(req, res){
    const sql = `INSERT INTO color SET ${connection.escape(req.body)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}
//Eliminar color de vehiculo
const eliminar_colorDeVehiculo = async function(req, res){
    const id = req.params.id; 
    const sql = `DELETE FROM color WHERE id_color = ${connection.escape(id)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}

module.exports = {
    seleccionar_colorDeVehiculo,
    actualizar_colorDeVehiculo,
    insertar_colorDeVehiculo,
    eliminar_colorDeVehiculo
};