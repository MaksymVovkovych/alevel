import React, {ReactElement, FC, useEffect, useState} from "react";
import {Box, CircularProgress, Container, Grid, Pagination} from '@mui/material'
import * as userApi from "../../api/Resources"
import {IRecource} from "../../interfaces/ResourceInterface";
import ResourceCard from "./components";

const Home: FC<any> = (): ReactElement => {
    const [users, setUsers] = useState<IRecource[] | null>(null)
    const [totalPages, setTotalPages] = useState<number>(0)
    const [currentPage, setCurrentPage] = useState<number>(1)
    const [isLoading, setIsLoading] = useState<boolean>(false)

    useEffect(() => {
        const getUser = async () => {
            try {
                setIsLoading(true)
                const res = await userApi.getResources(currentPage)
                setUsers(res.data)
                setTotalPages(res.total_pages)
            } catch (e) {
                if (e instanceof Error) {
                    console.error(e.message)
                }
            }
            setIsLoading(false)
        }
        getUser()
    }, [currentPage])

  return (
      <Container>
          <Grid container spacing={4} justifyContent="center" my={4}>
              {isLoading ? (
                  <CircularProgress />
              ) : (
                  <>
                      {users?.map((item) => (
                          <Grid key={item.id} item lg={4} md={4} xs={12}>
                              <ResourceCard {...item} />
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
              <Pagination  count={totalPages} page={currentPage} onChange={ (event, page)=> setCurrentPage(page)} />
          </Box>
      </Container>
  );
};

export default Home;