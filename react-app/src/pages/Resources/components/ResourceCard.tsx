import { Card, CardContent, CardMedia, Typography } from "@mui/material"
import {FC,ReactElement} from 'react';
import {IRecource} from "../../../interfaces/ResourceInterface";

const RecourceCard : FC<IRecource> = (props): ReactElement =>{
    return(
        <Card sx={{maxWidth:250 , backgroundColor: "secondary.main", color: "secondary.contrastText"}}>
            
            <CardContent>
            <Typography noWrap gutterBottom variant="h6" component="div">
                        {props.name}
                    </Typography>
                    <Typography variant="body2" color="secondary.light">
                        {props.year} {props.color} {props.pantone_value}
                    </Typography>
            </CardContent>
        </Card>
    )
}

export default RecourceCard