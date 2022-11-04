import { useState, useContext } from "react";
import AppBar from "@mui/material/AppBar";
import Box from "@mui/material/Box";
import Toolbar from "@mui/material/Toolbar";
import Typography from "@mui/material/Typography";
import IconButton from "@mui/material/IconButton";
import MenuIcon from "@mui/icons-material/Menu";
import { MenuItem, Menu, Divider, Badge, Stack } from "@mui/material";
import { ThemeProvider, createTheme } from "@mui/material/styles";
import GitHubIcon from "@mui/icons-material/GitHub";
import AutoStoriesIcon from '@mui/icons-material/AutoStories';

import { useRouter } from "next/router";

import { Language, TreesContext } from "../../providers/context";

import {
  ForestOutlined as ForestOutlinedIcon,
  NotificationsNoneOutlined as NotificationsNoneOutlinedIcon,
} from "@mui/icons-material";
import { withTranslations } from "../../helpers";
import styled from "@emotion/styled";

const darkTheme = createTheme({
  palette: {
    mode: "dark",
    primary: {
      main: "#1976d2",
    },
  },
});

const Component = ({ changeLanguage, t, language }: any) => {
  const [anchorEl, setAnchorEl] = useState(null);

  const handleMenu = (event: any) => {
    setAnchorEl(event.currentTarget);
  };

  const router = useRouter();
  const handleClose = (url: string) => {
    setAnchorEl(null);
    router.push(url);
  };

  const handleChangeLanguage = (lang: string) => {
    setAnchorEl(null);
    changeLanguage(lang);
  };

  const numberOfTrees = useContext(TreesContext);

  const otherLanguage: Language =
    language == Language.English ? Language.French : Language.English;

  return (
    <Box sx={{ flexGrow: 1 }}>
      <ThemeProvider theme={darkTheme}>
        <AppBar>
          <Toolbar>
            <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
              {/* Photos */}
            </Typography>
            <Box
              sx={{ display: { xs: "none", md: "flex" } }}
              alignContent="center"
              justifyContent="center"
            >
              <Stack padding={2} direction="row">
                <PaddingLink
                  href="https://github.com/jonattfin/ecosia-clone-web"
                  target="_blank"
                  rel="noreferrer"
                >
                  <GitHubIcon fontSize="small"></GitHubIcon>
                </PaddingLink>
                <PaddingLink
                  href="https://www.chromatic.com/builds?appId=629e38adc84b50004a0c06fc"
                  target="_blank"
                  rel="noreferrer"
                >
                  <AutoStoriesIcon fontSize="small" color="secondary"></AutoStoriesIcon>
                </PaddingLink>
                <PaddingLink
                  href="https://sonarcloud.io/summary/new_code?id=jonattfin_ecosia-clone2"
                  target="_blank"
                  rel="noreferrer"
                >
                  <img src="https://sonarcloud.io/api/project_badges/measure?project=jonattfin_ecosia-clone2&metric=alert_status" />
                </PaddingLink>
              </Stack>

              <IconButton size="small" aria-label="" color="inherit">
                <Badge badgeContent={numberOfTrees} color="success">
                  <ForestOutlinedIcon color="info" />
                </Badge>
              </IconButton>
              <IconButton size="small" aria-label="" color="inherit">
                <Badge color="default">
                  <NotificationsNoneOutlinedIcon color="disabled" />
                </Badge>
              </IconButton>
            </Box>
            <Menu
              id="menu-appbar"
              anchorEl={anchorEl}
              anchorOrigin={{
                vertical: "top",
                horizontal: "right",
              }}
              keepMounted
              transformOrigin={{
                vertical: "top",
                horizontal: "right",
              }}
              open={Boolean(anchorEl)}
              onClose={handleClose}
            >
              {getPages().map(({ slug, url }, index) => (
                <MenuItem
                  key={`menuItem_${index}`}
                  onClick={() => handleClose(url)}
                >
                  {t(slug)}
                </MenuItem>
              ))}
              <Divider />
              <MenuItem onClick={() => handleChangeLanguage(otherLanguage)}>
                {otherLanguage}
              </MenuItem>
            </Menu>
            <IconButton
              size="large"
              aria-label="account of current user"
              aria-controls="menu-appbar"
              aria-haspopup="true"
              onClick={handleMenu}
              color="inherit"
            >
              <MenuIcon color="primary" />
            </IconButton>
          </Toolbar>
        </AppBar>
      </ThemeProvider>
    </Box>
  );
};

const getPages = () => {
  return [
    { url: "/", slug: "home", icon: "home" },
    { url: "/how-it-works", slug: "howItWorks", icon: "build" },
    { url: "/about-us", slug: "aboutUs", icon: "help" },
    { url: "/mobile", slug: "mobileApp", icon: "mobile-phone" },
    { url: "/privacy", slug: "privacy", icon: "shield" },
  ];
};

// Styled Components

const PaddingLink = styled.a`
  padding: 0px 5px;
`;

// translations

const translations = {
  [Language.English]: {
    home: "Home",
    howItWorks: "How Ecosia works",
    aboutUs: "About us",
    mobileApp: "Mobile app",
    privacy: "Privacy",
  },
  [Language.French]: {
    home: "Home",
    howItWorks: "Comment fonctionne Ecosia",
    aboutUs: "Qui sommes-nous",
    mobileApp: "Application mobile",
    privacy: "Vie privée",
  },
};

export default withTranslations(translations)(Component);
