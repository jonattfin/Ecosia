import { useContext } from "react";
import { LanguageContext } from "../../providers/context";
import AboutUsComponent from "./about-us-component";

export default function Component() {
  const language = useContext(LanguageContext);
  return <AboutUsComponent {...{ language }} />;
}
