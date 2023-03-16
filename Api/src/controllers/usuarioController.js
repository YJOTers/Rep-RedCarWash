'use strict'
const util = require('util');
const connection = require('../bd/db');
const query = util.promisify(connection.query).bind(connection);
const bcrypt = require('bcrypt');

function isEmptyObject(obj) {
    return !Object.keys(obj).length;
}

//Seleccionar usuario cliente y empleado
const seleccionar_usuario = async function(req, res){
    const correo_uc = req.body.correo_uc;
    const clave_uc = req.body.clave_uc;
    const sql1 = `SELECT clave_uc FROM usuarios WHERE correo_uc = ${connection.escape(correo_uc)}`;
    const reg1 = await query(sql1);
    if(isEmptyObject(reg1)){
        res.status(200).send(reg1);
    }else{
        const data = Object.values(JSON.parse(JSON.stringify(reg1)));
        const clave_hash = data[0].clave_uc;
        const esLaClave = bcrypt.compareSync(clave_uc, clave_hash);
        if(esLaClave)
        {
            const sql = `SELECT * FROM usuarios WHERE correo_uc = ${connection.escape(correo_uc)} AND clave_uc = ${connection.escape(clave_hash)}`;
            const reg = await query(sql);
            res.status(200).send(reg);
        }
    }
}
//Seleccionar usuarios empleados del cliente
const seleccionar_listaUsuarios = async function(req, res){
    const idEmpleado_uc = req.params.ide;
    const sql = `SELECT * FROM usuarios WHERE idEmpleado_uc = ${connection.escape(idEmpleado_uc)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}
//Seleccionar usuarios por correo
const seleccionar_usuarioPorCorreo = async function(req, res){
    const correo_uc = req.params.correo;
    const sql = `SELECT * FROM usuarios WHERE correo_uc = ${connection.escape(correo_uc)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}
//Actualizar usuario cliente y empleado
const actualizar_usuario = async function(req, res){
    const id = req.params.id;
    const clave_uc = req.body.clave_uc;
    const sql1 = `SELECT clave_uc FROM usuarios WHERE id_uc = ${connection.escape(id)}`;
    const reg1 = await query(sql1);
    if(isEmptyObject(reg1)){
        res.status(200).send(reg1);
    }else{
        const data = Object.values(JSON.parse(JSON.stringify(reg1)));
        const clave_hash = data[0].clave_uc;
        if(clave_uc != clave_hash)
        {
            req.body.clave_uc = bcrypt.hashSync(clave_uc, 10);
        }
        const sql = `UPDATE usuarios SET ${connection.escape(req.body)} WHERE id_uc = ${connection.escape(id)}`;
        const reg = await query(sql);
        res.status(200).send(reg);
    }
}
//Insertar usuario empleado (Por usuario cliente)
const insertar_usuario = async function(req, res){
    req.body.clave_uc = bcrypt.hashSync(req.body.clave_uc, 10);
    const sql = `INSERT INTO usuarios SET ${connection.escape(req.body)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}
//Eliminar usuario empleado (Por usuario cliente)
const eliminar_usuario = async function(req, res){
    const id = req.params.id;
    const sql = `DELETE FROM usuarios WHERE id_uc = ${connection.escape(id)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}

module.exports = {
    seleccionar_usuario,
    seleccionar_listaUsuarios,
    seleccionar_usuarioPorCorreo,
    actualizar_usuario,
    insertar_usuario,
    eliminar_usuario
};