import React, { FC, ReactElement } from "react";
import {
  Box,
  Link,
  Container,
  IconButton,
  Menu,
  MenuItem,
  Toolbar,
  Typography,
} from "@mui/material";
import MenuIcon from "@mui/icons-material/Menu";
import { routes } from "../../routes";
import { NavLink } from "react-router-dom";

const Navbar: FC = (): ReactElement => {
  return (
    <Box
      sx={{
        width: "100%",
        height: "auto",
        backgroundColor: "primary.main",
      }}
    >
        <Toolbar disableGutters>
            <Box
              sx={{
                display: "flex",
                flexDirection: "row",
                justifyContent: "flex-start",
                alignItems: "center",
                marginLeft: "1rem",
              }}
            >
              {routes.map((page) => (
               !!page.enabled && <Link
                  key={page.key}
                  component={NavLink}
                  to={page.path}
                  color={(theme) => theme.palette.primary.contrastText}
                  underline="none"
                  variant="button"
                  sx={{ fontSize: "large", marginLeft: "2rem" }}
                >
                  {page.title}
                </Link>
              ))}
            </Box>
        </Toolbar>
    </Box>
  );
};

export default Navbar;