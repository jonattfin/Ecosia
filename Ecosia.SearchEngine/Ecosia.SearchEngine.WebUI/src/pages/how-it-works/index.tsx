import { useContext } from "react";
import { LanguageContext } from "../../providers/context";
import HowItWorksComponent from "./how-it-works-component";

export default function Component() {
  const language = useContext(LanguageContext);
  return <HowItWorksComponent {...{ language }} />;
}
