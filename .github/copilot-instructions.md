# GitHub Copilot Instructions for RimWorld Modding Project: Coffee and Tea

## Mod Overview and Purpose
This mod introduces new gameplay elements focused on coffee and tea consumption in RimWorld. It enhances the drug policy system to include various effects and interactions with coffee and tea. The goal is to enrich the players' experience by offering new joy activities and impacts on colonists' moods based on their beverage preferences.

## Key Features and Systems
- **Drug Policy Enhancements**: Generate starting drug policies to include specific rules for coffee and tea intake.
- **Joy Mechanics**: Introduce new joy-givers related to coffee and tea ingestion.
- **Thought Workers**: Implement thought workers to manage mood and thought effects resulting from coffee and tea consumption.
- **Harmony Patching**: Use Harmony to patch existing game methods for integration of new functionalities.
- **Integration with Vanilla Systems**: Seamlessly integrate new drug policies and joy-giving mechanics with the existing game mechanics.

## Coding Patterns and Conventions
- **Class Naming**: Classes are named using PascalCase, clearly indicating their responsibilities (e.g., `JoyGiver_Ingest_CanIngestForJoy`, `DrugPolicyDatabase_GenerateStartingDrugPolicies`).
- **Method Organization**: Methods are organized within their relevant classes, ensuring that each class has a single responsibility.
- **Internal and Public Classes**: Use of `public` and `internal` access modifiers to control the accessibility of classes, promoting encapsulation where necessary.
- **Inheritance and Polymorphism**: Usage of base classes like `IngestionOutcomeDoer` to extend and create specialized ingestion effects for coffee and tea.

## XML Integration
- **Def Files**: Utilize XML files within the RimWorld modding framework to define new items, thoughts, and other game objects related to coffee and tea.
- **Mod Load Order**: Ensure XML definitions are loaded correctly to allow seamless integration with existing game content.

## Harmony Patching
- **Patch Class**: Implement a static class (`HarmonyPatches`) dedicated to managing all Harmony patches.
- **Method Patching**: Use `HarmonyPatch` attribute to target specific methods in the game for augmentation or modification.
- **Postfix and Prefix Methods**: Apply `Postfix` and `Prefix` methods in Harmony patches to safely insert additional logic before or after existing method executions.

## Suggestions for Copilot
To enhance development efficiency and code quality with GitHub Copilot, consider the following suggestions:
- **Generate Boilercode**: Use Copilot to generate snippets for repetitive tasks such as class definitions and method structures.
- **XML Definitions**: Employ Copilot to automate the creation of XML definition templates for new game objects.
- **Harmony Patch Templates**: Leverage Copilot to draft basic Harmony patch structures, ensuring all necessary attributes and stubs are present.
- **Testing and Debugging**: Utilize Copilot to generate unit tests and debug methods to verify new feature integrations within the mod.
- **Documentation and Comments**: Prompt Copilot to assist in generating comments and documentation for complex logic or patches applied, maintaining a high level of code clarity.

This set of instructions guides developers in expanding the mod with additional beverage-themed mechanics and ensures uniformity in developing new features and patches. Using these guidelines, maintain a consistent approach to mod development, integration, and collaboration.
