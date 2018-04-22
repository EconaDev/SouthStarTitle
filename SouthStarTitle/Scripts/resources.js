
Ext.onReady(function() {


    var button = Ext.get('showbtn');

    button.on('click', function() {

        // tabs for the center
        var tabs = new Ext.TabPanel({
            region: 'center',
            margins: '3 3 3 0',
            activeTab: 0,
            defaults: { autoScroll: true },

            items: [{
                title: 'A',
                html:   "<ul>" +
                        "<li>" +
                        "<b>Abstract of Title</b> - A condensed history" + 
                        "or summary of all transactions affecting a particular" +
                        "tract of land." +
                        "</li>" +
                        "<li>" +
                        "<br />" +
                        "<b>Access</b> - The right to enter and leave" +  
                        "a tract of land from a public way. &#8220;Oftentimes" + 
                        "the right to enter and leave over the lands of another.&quot;" +
                        "</li>" +
                        "<li>" +
                        "<br />" +
                        "<b>Accretion</b> - The slow build uli of lands by natural forces such as" +
                        "wind, wave or water." +
                        "</li>" +
                        "<li>" +
                        "<br />" +
                        "<b>Acknowledgement</b> - The act by which a party executing a legal document" +
                        "goes before an authorized officer or notary public and declares the same to be his" +
                        "voluntary act and deed." +
                        "</li>" +
                        "<li>" +
                        "<br />" +
                        "<b>Acre</b> - A tract of land 208.71 feet square and containing 43,560" +
                        "square feet of land." +
                        "</li>" +
                        "<li>" +
                        "<br />" +
                        "<b>Administrator</b> - A person appointed by a probate court to settle" +
                        "the affairs of an individual dying without a will. The term is administratrix if" +
                        "such a person is a woman." +
                        "</li>" +
                        "<li>" +
                        "<br />" +
                        "<b>Adverse Possession</b> - A claim made against the lands of another" +
                        "by virtue of open and notorious possession of said lands by the claimant." +
                        "</li>" +
                        "<li>" +
                        "<br />" +
                        "<b>Affidavit</b> - A sworn statement in writing." +
                        "</li>" +
                        "<li>" +
                        "<br />" +
                        "<b>Air Rights</b> - The right to ownershili of everything above the physical" +
                        "surface of the land." +
                        "</li>" +
                        "<li>" +
                        "<br />" +
                        "<b>ALTA</b> - American Land Title Association, a national association" +
                        "of title insurance companies, abstractors and attorneys specializing in real property" +
                        "law which speaks for the title insurance and abstracting industry and establishes" +
                        "standard title policies and procedures, with headquarters in Washington, D.C." +
                        "</li>" +
                        "<li>" +
                        "<br />" +
                        "<b>Appurtenance</b> - Anything so annexed to land or used with it that" +
                        "it will pass with the conveyance of the land." +
                        "</li>" +
                        "<li>" +
                        "<br />" +
                        "<b>Assessment</b> - The imposition of a tax, charge or levy, usually according" +
                        "to established rates." +
                        "</li>" +
                        "<li>" +
                        "<br />" +
                        "<b>Assessor</b> - A public official who evaluates property for the purpose" +
                        "of taxation." +
                        "</li>" +
                        "<li>" +
                        "<br />" +
                        "<b>Assignee</b> - One to whom a transfer of interest is made. For example," +
                        "the assignee of a mortgage or contract.<br />" +
                        "</li>" +
                        "<li>" +
                        "<br />" +
                        "<b>Assignor</b> - One who makes an assignment. For example, the assignor" +
                        "of a mortgage or contract." +
                        "</li>" +
                        "<li>" +
                        "<br />" +
                        "<b>Attachment</b> - Legal seizure of property to force payment of a debt." +
                        "</li>" +
                        "<li>" +
                        "<br />" +
                        "<b>Attorney in Fact </b>- One who holds a power of attorney from another" +
                        "allowing him to execute legal documents such as deeds. mortgages, etc. on behalf" +
                        "of the grantor of the power." +
                        "<br />" +
                        "</li>" +
                        "</ul>" 
            }, {
                title: 'B',
                html:   "<ul>" +
                        "<li> " +
                        "<b>Bankrupt</b> - A person who, through " +
                        "a court proceeding, is relieved from the payment of " +
                        "all his debts after surrender of all his assets to " +
                        "a court appointed trustee. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Bench Mark</b> - A mark on a permanent " +
                        "object indicating elevation and serving as a reference " +
                        "in land surveys." +
                        "<br />" +
                        "</li>" +
                        "</ul>"
            }, {
                title: 'C',
                html:   "<ul>" +
                        "<li> " +
                        "<b>Chain of Title</b> - A term applied to " +
                        "the past series of transactions and documents affecting " +
                        "the title to a particular parcel of land. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Clear Title</b> - One which is not encumbered " +
                        "or burdened with defects. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Clouded Title</b> - An encumbered title. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Commitment to Insure</b> - A report issued " +
                        "by a title insurance company, or its agent, showing " +
                        "the condition of the title and committing the title " +
                        "insurance company to issue a form policy as designated " +
                        "in the commitment upon compliance with and satisfaction " +
                        "of requirements set forth in the commitment. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Condemnation</b> - Taking private property " +
                        "for public use through court proceedings. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Condition or Conditions</b> - A proviso " +
                        "in a deed or a will that upon the happening or failure " +
                        "to happen of a certain event, the title of the purchaser " +
                        "or devisee will be limited, enlarged, changed or terminated. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Conditions and Restrictions</b> - A common " +
                        "term used to designate the uses to which land may " +
                        "not be put and providing penalties for failure to " +
                        "comply. &#8220;Commonly used by land subdividers on " +
                        "newly platted areas.&#8221; " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Condominium</b> - A system of individual " +
                        "fee obligation paid or duo. &quot;For example, a pro " +
                        "rate of real property taxes or fire insurance.&#8221; " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Contract</b> - An agreement to sell and " +
                        "purchase under which title is withheld from the purchaser " +
                        "until such time as the required payments, to the seller " +
                        "have been completed. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Conveyance</b> - An instrument by which " +
                        "title to property is transferred; a deed. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Cooperative</b> - A residential multi-unit " +
                        "building owned by and operated for the benefit of " +
                        "persons living within. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Covenant</b> - An agreement written into " +
                        "deeds and other instruments promising performance " +
                        "or non-performance of certain acts, or stipulating " +
                        "certain uses or non-uses of the property. " +
                        "<br />" +
                        "</li>" +
                        "</ul>"
            }, {
                title: 'D',
                html:   "<ul>" +
                        "<li> " +
                        "<b>Deed</b> - A written document by which " +
                        "the ownership of land is transferred from one person " +
                        "to another. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Delivery</b> - The final and absolute " +
                        "transfer of a deed from seller to buyer in such a " +
                        "manner that it cannot be recalled by the seller. A " +
                        "necessary requisite to the transfer of title. " +
                        "<br />" +
                        "</li>" +
                        "</ul>"
            }, {
                title: 'E',
                html:   "<ul>" +
                        "<li> " +
                        "<b>Earnest Money</b> - Advance payment of " +
                        "part of the purchase price to bind a contract for " +
                        "property. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Easement</b> - An interest in land owned " +
                        "by another that entitles its holder to a specific " +
                        "limited use, such as laying a sewer, putting up electric " +
                        "power lines, or crossing the property. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Egress</b> - The right to leave a tract " +
                        "of land. &#8220;Often used interchangeably with access.&#8221; " +
                        "(See Access) " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Eminent Domain</b> - The power of the " +
                        "state to take private property for public use upon " +
                        "payment of just compensation. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Encroachment</b> - A fixture, such as " +
                        "a house, wall or fence, which intrudes upon another&#8217;s " +
                        "property. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Encumbrance</b> - A lien, liability or " +
                        "charge upon a parcel of land. </li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Escrow</b> - A procedure whereby a disinterested " +
                        "third party handles legal documents and funds on behalf " +
                        "of a seller and buyer. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Examination of Title</b> - The interpretation " +
                        "of the record title to real property based on the " +
                        "title search or abstract. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Exception</b> - In legal descriptions " +
                        "that portion of lands to be deleted or excluded. &#8220;The " +
                        "term is often used in a different sense to mean an " +
                        "objection to title or encumbrance on title. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Executor</b> - A person appointed by " +
                        "the probate court to carry out the terms of a will. " +
                        "&#8220;The term is executrix if such person be a woman. " +
                        "<br />" +
                        "</li>" +
                        "</ul>"
            }, {
                title: 'F',
                html:   "<ul>" +
                        "<li> " +
                        "<b>Fee Simple Estate</b> - The greatest " +
                        "interest in a parcel of land that it is possible to " +
                        "own. Sometimes designated simply as Fee. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Financing Statement</b> - A document " +
                        "prepared for filing with the Register of Deeds or " +
                        "Secretary of State indicating that personal property " +
                        "or fixtures in encumbered with a debt. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Fixtures</b> - Any item of&#8217; personal " +
                        "property so attached to real property that it becomes " +
                        "a part of the real property." +
                        "<br />" +
                        "</li>" +
                        "</ul>"
            }, {
                title: 'G',
                html:   "<ul>" +
                        "<li> " +
                        "<b>Grantee</b> - A person who acquires an " +
                        "interest in land by deed, grant, or other written " +
                        "instrument. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Grantor</b> - A person who, by a written " +
                        "instrument, transfers to another an interest in land." +
                        "<br />" +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Guardian</b> - One appointed by the court " +
                        "to administer the affairs of an individual not capable " +
                        "of administering his own affairs. " +
                        "<br />" +
                        "</li>" +
                        "</ul>"
            }, {
                title: 'H',
                 html:  "<ul>" +
                        "<li> " +
                        "<b>Heir</b> - One who might inherit or succeed " +
                        "to an interest in lands under the rules of law applicable " +
                        "where an individual dies without leaving a will. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Hiatus</b> - A gap or space unintentionally " +
                        "left between, when attempting to describe adjacent " +
                        "parcels of land. " +
                        "<br />" +
                        "</li>" +
                        "</ul>"
            }, {
                title: 'I',
                html:   "<ul>" +
                        "<li> " +
                        "<b>Improvements</b> - Those additions to " +
                        "raw lands tending to increase value such as buildings, " +
                        "streets, sewer, etc. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Indemnify</b> - To make payment for a " +
                        "loss. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Ingress</b> - The right to enter a tract " +
                        "of land. &#8220;Often used interchangeably with access.&#8221; " +
                        "(See Access) " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Insurance</b> - A contract of indemnity " +
                        "against specified perils. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Insurance of Title</b> - Insurance as " +
                        "to who owns a specified interest in designated real " +
                        "estate, and showing as exceptions to the insured interest " +
                        "the defects, liens and encumbrances which exist as " +
                        "against that insured interest. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Intestate</b> - Designates the estate " +
                        "or condition of failing to leave a will at death. " +
                        "&#8220;To die intestate.&#8221; " +
                        "<br />" +
                        "</li>" +
                        "</ul>"
            }, {
                title: 'J',
                html:   "<ul>" +
                        "<li> " +
                        "<b>Joint Tenancy</b> - Where two or more " +
                        "persons hold real estate jointly for life, the survivors " +
                        "to take the interest of the one who dies. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Judgment</b> - A decree of a court. &#8220;In " +
                        "practice this is the lien or charge upon the lands " +
                        "of a debtor resulting from the Court&#8217;s award " +
                        "of money to a creditor.&#8221; (See Judgment Lien) " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Judgment Docket</b> - The record book " +
                        "of a County Clerk where a judgment is entered in order " +
                        "that it may become a lien upon the property of the " +
                        "debtor. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Judgment Lien</b> - The charge upon the " +
                        "lands of a debtor resulting from the decree of a court " +
                        "properly entered in the judgment docket." +
                        "<br />" +
                        "</li>" +
                        "</ul>"
            }, {
                title: 'L',
                html:   "<ul>" +
                        "<li> " +
                        "<b>Landmark</b> - Any conspicuous object " +
                        "that helps establish land boundaries. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Lease</b> - A grant of the use of lands " +
                        "for a term of years in consideration of the payment " +
                        "of a monthly or annual rental. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Lessee</b> - One who takes lands upon " +
                        "a lease. Lessor - One who grants lands under a lease. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Lien</b> - A hold, a claim or a charge " +
                        "allowed a creditor upon the lands of a debtor. &#8220;Some " +
                        "examples are mortgage liens, judgment liens, mechanics " +
                        "liens.&#8221; " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Life Estate </b>- A grant of reservation " +
                        "of the right of use, occupancy and ownership for the " +
                        "life of an individual. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Lis Pendens</b> - A notice recorded in " +
                        "the official records of a county to indicate that " +
                        "a suit is pending affecting the lands where the notice " +
                        "is recorded. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Lot</b> - A measured parcel of and having " +
                        "fixed boundaries. " +
                        "<br />" +
                        "</li>" +
                        "</ul>"
            }, {
                title: 'M',
                html:   "<ul>" +
                        "<li> " +
                        "<b>Majority</b> - The age at which a person " +
                        "is entitled to handle his own affairs. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Marketable Title</b> - A good title about " +
                        "which there is no fair or reasonable doubt." +
                        "<br />" +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Mechanics Lien</b> - A lien allowed by " +
                        "statute to contractors, laborers and material-men " +
                        "on buildings, or other structures upon which work " +
                        "has been performed or materials supplied. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Metes and Bounds</b> - A description " +
                        "of land by courses and distances. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Monument of Survey</b> - Visible marks " +
                        "or indications left on natural or other objects indicating " +
                        "the lines and boundaries of a survey. May be posts, " +
                        "pillars, stones, cairns, and other such objects but " +
                        "may also be fixed natural objects, blazed trees, roads " +
                        "and even a water course. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Mortgage</b> - An instrument used to " +
                        "encumber land as security for a debt." +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Mortgagee</b> - A designation for the " +
                        "mortgage lender on lands. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Mortgagor</b> - A designation for the " +
                        "mortgage borrower on lands." +
                        "<br />" +
                        "</li>" +
                        "</ul>"
            }, {
                title: 'N',
                html:   "<ul>" +
                        "<li> " +
                        "<b>Notary</b> - One authorized to take acknowledgments. " +
                        "<br />" +
                        "</li>" +
                        "</ul>"
            }, {
                title: 'O',
                html:   "<ul>" +
                        "<li> " +
                        "<b>Ownership</b> - The right to possess " +
                        "and use property to the exclusion of others." +
                        "<br />" +
                        "</li>" +
                        "</ul>"
            }, {
                title: 'P',
                html:   "<ul>" +
                        "<li> " +
                        "<b>Patent</b> - A document issued for the " +
                        "purpose of granting public lands to an individual. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Plat or Plot</b> - A map representing " +
                        "a piece of land subdivided into lots with streets " +
                        "shown thereon. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Policy</b> - A written contract of title " +
                        "insurance policy. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Power of Attorney</b> - An instrument " +
                        "authorizing another to act on one&#8217;s behalf as " +
                        "his agent or attorney. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Power of Sale</b> - A clause inserted " +
                        "in a will, deed of trust or trust agreement authorizing " +
                        "the sale or transfer of land in accordance with the " +
                        "terms of the clause. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Pro-Rate</b> - To allocate between seller " +
                        "and buyer their proportionate share of an ownership " +
                        "of units in a multi-unit structure, combined with " +
                        "joint ownership of common areas of structure and land. " +
                        "<br />" +
                        "</li>" +
                        "</ul>"
            }, {
                title: 'Q',
                html:   "<ul>" +
                        "<li> " +
                        "<b>Quiet Title</b> - An action in District " +
                        "Court to remove record defects." +
                        "<br />" +
                        "</li>" +
                        "</ul>"
            }, {
                title: 'R',
                html:   "<ul>" +
                        "<li> " +
                        "<b>Range</b> - A part of tile government " +
                        "survey, being a strip of land 6 miles in width, and " +
                        "numbered east or west of the principal meridian. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Real Property</b> - Land and that which " +
                        "is affixed to it. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Redeem</b> - Literally &#8220;to buy " +
                        "back.&#8221; The act of buying back lands after a " +
                        "mortgage foreclosure, tax foreclosure, or other execution " +
                        "sale. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Reinsurance</b> - To insure again by " +
                        "transferring to another insurance company all or part " +
                        "of an assumed liability, thus spreading the loss risk " +
                        "any one company has to carry. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Right-of-Way</b> - The right which one " +
                        "has to pass across the lands of another. An easement. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Riparian</b> - Rights to use of water " +
                        "in lakes or rivers. " +
                        "<br />" +
                        "</li>" +
                        "</ul>"
            }, {
                title: 'S',
                html:   "<ul>" +
                        "<li>" +
                        "<b>Section or Section of Land</b> - A parcel of " +
                        "land comprising one square mile or 640 acres. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Set Back Lines</b> - Those lines which " +
                        "delineate the required distances for the location " +
                        "of structure in relation to the perimeter of the property. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Sub-surface Right</b> - The right to " +
                        "ownership of everything beneath the physical surface " +
                        "of the property. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Survey</b> - The process of measuring " +
                        "land to determine its size, location and physical " +
                        "description. " +
                        "<br />" +
                        "</li>" +
                        "</ul>"
            }, {
                title: 'T',
                html:   "<ul>" +
                        "<li> " +
                        "<b>Tenancy in Common</b> - An estate or " +
                        "interest in land held by two or more persons each " +
                        "having equal rights of possession and enjoyment but " +
                        "without any right of survivorship between the owners. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Tenant</b> - Any person in possession " +
                        "of real property with the owner&#8217;s permission. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Testate</b> - The estate or condition " +
                        "of leaving a will at death, &#8220;To die testate.&#8221; " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Testator</b> - A man who makes or has " +
                        "made a testament or will. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Testatrix</b> - A woman who makes or " +
                        "has made a testament or will. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Thence</b> - In surveying and in metes " +
                        "and bounds descriptions, the term designates that " +
                        "the course and distance given there after is a continuation " +
                        "of the course and distance given before. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Title</b> - The evidence or right which " +
                        "a person has to the ownership and possession of land. " +
                        "Commonly considered as a bundle or history of rights.&#8221; " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Title Defect </b>- Any legal right held " +
                        "by others to claim property or to make demands upon " +
                        "the owner. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Title Insurance</b> - Insurance against " +
                        "loss or damage resulting from defects or failure of " +
                        "title to a particular parcel of real property. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Title Search</b> - An examination of " +
                        "public records, laws and court decisions to disclose " +
                        "the current facts regarding ownership of real estate. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Township</b> - A division of territory " +
                        "6 miles square, containing 36 sections or 36 square " +
                        "miles. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Tract</b> - An area of land. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Trust</b> - A right of property held " +
                        "by one for the benefit of another. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Trustee</b> - A person holding property " +
                        "in trust. " +
                        "<br />" +
                        "</li>" +
                        "</ul>"
            }, {
                title: 'V',
                html:   "<ul>" +
                        "<li> " +
                        "<b>Vendee</b> - A purchaser of real property. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Vendor</b> - A seller of real property. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Vest</b> - To pass to a person an immediate " +
                        "right. Title may be said to vest in John Brown. " +
                        "<br />" +
                        "</li>" +
                        "</ul>"
            }, {
                title: 'W',
                html:   "<ul>" +
                        "<li> " +
                        "<b>Warranty</b> - An agreement and assurance " +
                        "by the grantor-of real property for himself and his " +
                        "heirs, to the effect that he is the owner and will " +
                        "be responsible. " +
                        "</li>" +
                        "<li> " +
                        "<br />" +
                        "<b>Will</b> - A written document properly " +
                        "witnessed, providing for the distribution of property " +
                        "owned by the deceased. " +
                        "<br />" +
                        "</li>" +
                        "</ul>"
                }]  
            });

            // Panel for the west
            var nav = new Ext.Panel({
                title: 'Navigation',
                region: 'west',
                split: true,
                width: 200,
                collapsible: true,
                margins: '3 0 3 3',
                cmargins: '3 3 3 3'
            });

            var win = new Ext.Window({
                title: 'Glossary Terms',
                closable: true,
                width: 650,
                height: 350,
                //border:false,
                plain: true,
                layout: 'border',

                items: [tabs]
            });

            win.show(this);
        });
    });