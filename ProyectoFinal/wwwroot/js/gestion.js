const detalles = (id) => {
    document.getElementById('idDetalles').value = id
    //console.log(document.getElementById('idDetalles').value)
    document.getElementById('formDetalles').submit()
}

const editar = (id) => {
    document.getElementById('idEditar').value = id
    document.getElementById('formEditar').submit()
}