using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;
using NUnit.Framework;
using Nest.Tests.Integration.Yaml;


namespace Nest.Tests.Integration.Yaml.IndicesGetFieldMapping
{
	public partial class IndicesGetFieldMappingTests
	{	


		[NCrunch.Framework.ExclusivelyUses("ElasticsearchYamlTests")]
		public class Raise404WhenTypeDoesntExistTests : YamlTestsBase
		{
			[Test]
			public void Raise404WhenTypeDoesntExistTest()
			{	

				//do indices.create 
				_body = new {
					mappings= new {
						test_type= new {
							properties= new {
								text= new {
									type= "string",
									analyzer= "whitespace"
								}
							}
						}
					}
				};
				this.Do(()=> this._client.IndicesCreatePost("test_index", _body));

				//do indices.get_field_mapping 
				this.Do(()=> this._client.IndicesGetFieldMapping("test_index", "not_test_type", "text"));

			}
		}
	}
}

