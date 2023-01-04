import React, {useState, useEffect} from 'react';
import Services from '../Services';

import {Container, Nav, Navbar, Button, Modal} from 'react-bootstrap';

export default function NavBar(){
    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const [itemName, setItemName] = useState("");
    const [description, setDescription] = useState("");
    const [unit, setUnit] = useState("");
    const [availableQty, setAvailableQty] = useState(0);
    const [unitPrice, setUnitPrice] = useState(0);

    function inputAllData(){
        var addNew = {
            "itemName": itemName,
            "description": description,
            "unit": unit,
            "availableQty": availableQty,
            "unitPrice": unitPrice
        }

        Services.postData(addNew)
            .then(({data}) =>{
                console.log(data);
                setItemName("");
                setDescription("");
                setUnit("");
                setAvailableQty(0);
                setUnitPrice(0);
                setShow(false);
                window.location.replace("/");
            }).catch(({response})=>{
                console.log(response);
            })
    }

    return(
        <>
            <Navbar bg="dark" variant="dark">
                <Container>
                    <Navbar.Brand href="/">Shopping App</Navbar.Brand>
                    <Nav className="me-auto">
                        {/* <Nav.Link href="/add">New</Nav.Link> */}
                        <Button variant="primary" onClick={(e) => handleShow()}>New</Button>
                    </Nav>
                </Container>
            </Navbar>

            <Modal show={show} onHide={handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title>Add New Stock.</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <div className='p-4'>
                        <div className="form-floating mb-4">
                            <input type="text" id="itemName" className="form-control" placeholder="Item Name" onChange={(e) => setItemName(e.target.value)}/>
                            <label className="form-label" htmlFor="itemName">Item Name</label>
                        </div>
                        <div className="form-floating mb-4">
                            <input type="text" id="description" className="form-control" placeholder="Description" onChange={(e) => setDescription(e.target.value)}/>
                            <label className="form-label" htmlFor="description">Description</label>
                        </div>
                        <div className="form-floating mb-4">
                            <select className="form-select" id="unit" placeholder="Unit" value={unit} onChange={(e) => setUnit(e.target.value)}>
                                <option value="" selected>_</option>
                                <option value="NOS">NOS</option>
                                <option value="KG">KG</option>
                                <option value="BAG">BAG</option>
                                <option value="LITER">LITER</option>
                                <option value="MITER">MITER</option>
                                <option value="BOTTLE">BOTTLE</option>
                            </select>
                            <label className="form-label" htmlFor="unit">Unit</label>
                        </div>
                        <div className="form-floating mb-4">
                            <input type="number" id="availableQty" className="form-control" placeholder="Available Qty" onChange={(e) => setAvailableQty(parseInt(e.target.value))}/>
                            <label className="form-label" htmlFor="availableQty">Available Qty</label>
                        </div>
                        <div className="form-floating mb-4">
                            <input type="number" id="unitPrice" className="form-control" placeholder="Unit Price" onChange={(e) => setUnitPrice(parseInt(e.target.value))}/>
                            <label className="form-label" htmlFor="unitPrice">Unit Price</label>
                        </div>
                    </div>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        Close
                    </Button>
                    <Button variant="primary" onClick={() => { handleClose(); inputAllData(); }}>
                        Save Changes
                    </Button>
                </Modal.Footer>
            </Modal>
        </>
    );
}