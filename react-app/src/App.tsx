import { CssBaseline, ThemeProvider } from "@mui/material";
import { createTheme } from "@mui/material/styles";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { routes as appRoutes } from "./routes";
import Layout from "./components/Layout/Layout";

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
  
  
  

  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <Router>
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
      </Router>
    </ThemeProvider>
  );
}

export default App;