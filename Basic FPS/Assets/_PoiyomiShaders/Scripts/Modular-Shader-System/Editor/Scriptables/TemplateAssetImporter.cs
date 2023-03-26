using System;
using System.IO;

using UnityEngine;

namespace Poiyomi.ModularShaderSystem
{
    [UnityEditor.AssetImporters.ScriptedImporter(1, MSSConstants.TEMPLATE_EXTENSION)]
    public class TemplateAssetImporter : UnityEditor.AssetImporters.ScriptedImporter
    { 
        //TODO: add icon
        public override void OnImportAsset(UnityEditor.AssetImporters.AssetImportContext ctx)
        {
            var subAsset = ScriptableObject.CreateInstance<TemplateAsset>();
            subAsset.Template = File.ReadAllText(ctx.assetPath);
            //Texture2D icon = Resources.Load<Texture2D>("Editor/Icons/Icon");
            ctx.AddObjectToAsset("Template", subAsset/*, icon*/);
            ctx.SetMainObject(subAsset);
        }

        public override bool SupportsRemappedAssetType(Type type)
        {
            return type.IsAssignableFrom(typeof(TemplateAsset));
        }
    }
}