import React, { useEffect, useState } from 'react';
import Services from '../Services';
import NavBar from './NavBar';
import { Container } from 'react-bootstrap';

export default function Home(){
    const[data, setData] = useState([{
        "id": "",
        "itemName": "",
        "description": "",
        "unit": "",
        "availableQty": "",
        "unitPrice": "",
        "createdAt": "",
        "updatedAt": ""
    }]);

    const [id, setID] = useState("");
    const [itemName, setItemName] = useState("");
    const [description, setDescription] = useState("");
    const [unit, setUnit] = useState("");
    const [availableQty, setAvailableQty] = useState(0);
    const [unitPrice, setUnitPrice] = useState(0);
    const [createdAt, setCreatedAt] = useState("");

    useEffect(() => {
        fetchData();
    }, []);

    function fetchData(){
        Services.getData().then(({data})=>{
            console.log(data);
            setData(data)
        })
        .catch(({response})=>{
            console.log(response);
        })
    }

    function fetchDataById(id: number){
        Services.getDataById(id).then(({data})=>{
            console.log(data);
            setID(data.id);
            setItemName(data.itemName);
            setDescription(data.description);
            setAvailableQty(data.availableQty);
            setUnitPrice(data.unitPrice);
            setCreatedAt(data.createdAt);
        })
        .catch(({response})=>{
            console.log(response);
        })
    }

    function updateData(){
        var updatedData = {
            "id": id,
            "itemName": itemName,
            "description": description,
            "unit": unit,
            "availableQty": availableQty,
            "unitPrice": unitPrice,
            "createdAt": createdAt
        }
        Services.putData(updatedData).then(({data}) =>{
            console.log(data);
            fetchData();
        }).catch(({response})=>{
            console.log(response);
        })
    }

    function deleteData(id: number){
        if(window.confirm(`Confirm to delete ${id}.`)){
            Services.deleteData(id).then(({data}) =>{
                console.log(data);
                fetchData();
            }).catch(({response})=>{
                console.log(response);
            })
        }
    }

    return(
        <>
            <NavBar/>

            <Container>
                <table className="table">
                    <thead>
                        <tr>
                            <th scope="col">Song</th>
                            <th scope="col">Artist</th>
                            <th scope="col">Year</th>
                        </tr>
                    </thead>
                    <tbody>
                        { data.map((dt) => 
                            <tr>
                                <td scope="row"></td>
                                <td></td>
                                <td></td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </Container>
        </>
    );
}