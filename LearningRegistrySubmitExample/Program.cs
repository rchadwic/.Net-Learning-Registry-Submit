﻿// Copyright 2011 ADL - http://www.adlnet.gov/
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LR;
using LR.RDDD;
using LR.Paradata;
namespace LearningRegistrySubmitExample
{
    class Program
    {
        static void Main(string[] args)
        {

            //create a document and an envelop
            lr_Envelope env = new lr_Envelope();
            lr_document doc = new lr_document();

            //Add the keys from the contentobject to the keys for the document
            doc.keys.Add("3DR");
            string[] keywords = new string[] { "keyword1", "keyword2" };
            foreach (string key in keywords)
                doc.keys.Add(key);

            //This is the URI of the resource this data describes
            doc.resource_locator = "http://www.example.com/LRTest.html";

            //Submitted by the ADL3DR agent
            doc.identity.submitter = LR.Settings.LR_Integration_SubmitterName();
            doc.identity.signer = LR.Settings.LR_Integration_SignerName();
            doc.identity.submitter_type = new lr_submitter_type.agent();

            //The data is paradata
            doc.resource_data_type = new lr_resource_data_type.paradata();

            //Set ActivityStream as the paradata schema
            doc.payload_schema.Add(new lr_schema_value.paradata.LR_Paradata_1_0());

            LR.Paradata.lr_Activity activity = new lr_Activity();
            //Create a paradata object
            LR.Paradata.lr_Paradata pd = activity.activity;

            //Create a complex actor type, set to 3dr user
            lr_Actor.lr_Actor_complex mActor = new lr_Actor.lr_Actor_complex();
            mActor.description.Add("AnonymousUser");
            mActor.objectType = "3DR User";

            //Set the paradata actor
            pd.actor = mActor;

            //Create a complex verb type
            lr_Verb.lr_Verb_complex verb = new lr_Verb.lr_Verb_complex();
            verb.action = "Published";
            verb.context.id = "";
            verb.date = DateTime.Now;
            verb.measure = null;

            //Set the paradata verb
            pd.verb = verb;

            //Create a complex object type
            lr_Object.lr_Object_complex _object = new lr_Object.lr_Object_complex();
            _object.id = "an object id";

            //Set the paradata object
            pd._object = _object;

            //A human readable description for the paradata
            pd.content = "The a user uploaded a new model which was assigned the PID ...";

            //The resource_data of this Resource_data_description_document is the inline paradata
            doc.resource_data = activity;
            env.documents.Add(doc);

            //sign the envelope 
            env.Sign(LR.Settings.LR_Integration_KeyPassPhrase(), LR.Settings.LR_Integration_KeyID(), LR.Settings.LR_Integration_PublicKeyURL());

            //Serialize and publish
            env.Publish();

        }
    }
}
