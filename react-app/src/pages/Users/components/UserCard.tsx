import { Card, CardContent, CardMedia, Typography } from "@mui/material"
import {FC,ReactElement} from 'react';
import {IUser} from "../../../interfaces/UserInterface";

const UserCard : FC<IUser> = (props): ReactElement =>{
    return(
        <Card sx={{ maxWidth: 250, backgroundColor: "secondary.main", color: "secondary.contrastText"}}> 
                <CardMedia
                    component="img"
                    height="250"
                    image={props.avatar}
                    alt={props.email}
                />
                <CardContent >
                    <Typography noWrap gutterBottom variant="h6" component="div">
                        {props.email}
                    </Typography>
                    <Typography variant="body2" color="secondary.light">
                        {props.first_name} {props.last_Name}
                    </Typography>
                </CardContent>
        </Card>
    )
}

export default UserCard