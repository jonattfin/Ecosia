import styled from "@emotion/styled";

export { default as Footer } from "./footer";
export { default as Header } from "./header";
export { default as Links } from "./links";
export { default as Image } from "./image";
export { default as Pie } from './pie';

// Shared Styled Components & other styles

export const enum AppColor {
  AliceBlue = "aliceblue",
  Teal = "teal",
  Grey = "#f9f9f9",
}

export const MainTitleDiv = styled.div`
  font-size: 1.5em;
  color: ${AppColor.Teal};
  text-transform: uppercase;
  padding: 10px 0px;
`;

export const MainSubtitleDiv = styled.div`
  font-size: 2em;
`;

export const MainSubtitleKickDiv = styled.div`
  font-size: 4em;
`;

export const LinkDiv = styled.div`
  text-align: right;
  padding-top: 10px;
  padding-right: 20px;
`;
