import  {ReactElement, FC} from "react";
import {Box, CircularProgress, Container, Grid, Pagination} from '@mui/material'
import {observer} from 'mobx-react-lite'
import ResourceCard from "./components";
import ResourcesStore from "./RecourcesStore";

const resources = new ResourcesStore();

const Resources: FC<any> = (): ReactElement => {
   
  return (
      <Container>
          <Grid container spacing={4} justifyContent="center" my={4}>
              {resources.isLoading ? (
                  <CircularProgress />
              ) : (
                  <>
                      {resources.resources?.map((item) => (
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
              <Pagination count={resources.totalPages}
                          page={resources.currentPage}
                          onChange={ async (event, page)=> await resources.changePage(page)} />
          </Box>
      </Container>
  );
};

export default observer(Resources);