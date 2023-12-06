import  {ReactElement, FC} from "react";
import {Box, CircularProgress, Container, Grid, Pagination} from '@mui/material'
import {observer} from 'mobx-react-lite'
import UserCard from "./components";
import UsersStore from "./UsersStore";

const userStore = new UsersStore();

const Users: FC<any> = (): ReactElement => {



  return (
      <Container>
          <Grid container spacing={4} justifyContent="center" my={4}>
              {userStore.isLoading ? (
                  <CircularProgress />
              ) : (
                  <>
                      {userStore.users?.map((item) => (
                          <Grid key={item.id} item lg={4} md={4} xs={12}>
                              <UserCard {...item} />
                          </Grid>
                      ))}
                  </>
              )}
          </Grid>
          <Box
              sx={{
                  display: 'flex',
                  justifyContent: 'center'
              }}
          >
              <Pagination sx={{color: "secondary.contrastText"}}
               count={userStore.totalPages}
                page={userStore.currentPage}
                onChange={ async (event, page)=> await userStore.changePage(page)} />
          </Box>
      </Container>
  );
};

export default observer(Users);