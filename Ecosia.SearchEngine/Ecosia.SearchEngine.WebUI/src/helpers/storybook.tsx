import { Language } from "../providers/context";

export function withLanguageControls(
  CustomComponent: any,
  extraArgs: any = {}
) {
  const DecoratedComponent = (args: any) => {
    return <CustomComponent {...args} />;
  };
  applyLanguageArguments(DecoratedComponent);

  return DecoratedComponent;

  function applyLanguageArguments(ComponentFunction: any) {
    ComponentFunction.args = {
      ...ComponentFunction.args,
      ...extraArgs,
      language: Language.English,
    };

    ComponentFunction.argTypes = {
      ...ComponentFunction.argTypes,
      language: {
        options: [Language.English, Language.French],
        control: { type: "select" },
      },
    };
  }
}
