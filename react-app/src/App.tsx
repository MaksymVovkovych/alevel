import { CssBaseline, ThemeProvider } from "@mui/material";
import { createTheme } from "@mui/material/styles";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { routes as appRoutes } from "./routes";
import Layout from "./components/Layout/Layout";
import { createContext, useState } from "react";
import MainStore from "./MainStore"
import { IMainStore } from "./interfaces/IMainStore";

const stores: IMainStore = {

  'authStore': new MainStore()
}


export const contextStore = createContext(stores);

function App() {
  // define theme
  const theme = createTheme({
    palette: {
      primary: {
        light: "#757575", 
        main: "#000000",  
        contrastText: "#FFFFFF"
      },
      secondary: {
        main: "#1E1E1E",
        light: "#757575", 
        contrastText: "#FFFFFF"
      },
    },
  });
  
  const [mainContext, setMainContext] = useState(stores);

  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <Router>
        <contextStore.Provider value={mainContext}>
          <Layout>
            <Routes>
              {appRoutes.map((route) => (
                <Route
                  key={route.key}
                  path={route.path}
                  element={<route.component />}
                />
              ))}
            </Routes>
          </Layout>
        </contextStore.Provider>
      </Router>
    </ThemeProvider>
  );
}

export default App;